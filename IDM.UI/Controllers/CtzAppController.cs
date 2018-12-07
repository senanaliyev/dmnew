using IDM.DTO;
using IDM.Service;
using IDM.UI.Class;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace IDM.UI.Controllers
{
    [Authorize]
    [MyActionFilter]
    public class CtzAppController : Controller
    {
        DocTypeService doctype = new DocTypeService();
        ContactTypeService conType = new ContactTypeService();
        AttachFileTypeService attFileType = new AttachFileTypeService();
        CitizenDoc_Service ctzServ = new CitizenDoc_Service();
        DocumentService doc = new DocumentService();
        DocumentFilesService docFiles = new DocumentFilesService();
        Region_Service regionServ = new Region_Service();
        EmployeeService empServ = new EmployeeService();
        Gender_Service genderServ = new Gender_Service();
        SocialStatus_Service socialStatusServ = new SocialStatus_Service();
        Category_Service categoryServ = new Category_Service();
        Company_Service compServ = new Company_Service();


        public ActionResult RegViewDocument(long id)
        {
            var data = ctzServ.GetCtzDocumentByDocID(id);
            ViewBag.AttachFileList = new DocumentFilesService().GetListByDocID(id);
            if (ViewBag.AttachFileList != null)
            {
                foreach (var item in ViewBag.AttachFileList)
                {
                    data.pageCount = data.pageCount + int.Parse(item.dfPageCount);
                }
            }
            return PartialView("_RegViewDocument", data);
        }

        // GET: CtzApp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            return PartialView("Search");
        }
        public ActionResult SearchDocument(string docregno)
        {
            return Json(new { data = doc.SearchByDocNo(docregno) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchDocumentByNameSurname(string name, string surname)
        {
            return Json(new { data = doc.SearchByNameSurname(name, surname) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            ViewBag.DocTypes = doctype.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.CtzApp);
            ViewBag.AppealCharacter = new AppealCharacter_Service().GetList();
            ViewBag.AppealType = new AppealTypeService().GetList();
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();
            ViewBag.UnID = Guid.NewGuid().ToString();
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.User = empServ.GetUserListByPositionStatus();
            ViewBag.Gender = genderServ.GetList();
            ViewBag.SocialStatus = socialStatusServ.GetList();
            ViewBag.Category = categoryServ.GetList();
            ViewBag.Company = compServ.GetRows();
            //ViewBag.Employees = new SelectList((from e in emp.GetList()
            //                                    select new
            //                                    {
            //                                        id = e.empID,
            //                                        title = e.empName + " " + e.empSurname
            //                                    }), "id", "title");
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(DocumentDTO DocEntity, CitizenDoc_DTO ctzDocEntity, string dfGUID)
        {
            int docContentType = (int)Enums.ContentTypes.CtzApp;
            DocEntity.docContentType = docContentType;

            long docID = doc.Insert(DocEntity);

            /// begin - insert log operation 
            //DocOperationLog_Service docOpLogServ = new DocOperationLog_Service();
            //docOpLogServ.Insert(new DocOperationLog_DTO()
            //{
            //    docID = docID,
            //    docContentType= docContentType,
            //    userID = Convert.ToInt32(Session["userID"]),
            //    operationID=0
            //});

            /// end - insert log operation 

            ctzDocEntity.docID = docID;
            ctzServ.Insert(ctzDocEntity);

            AttachFileTypeService attFiles = new AttachFileTypeService();
            attFiles.UpdateDocID(docID, dfGUID);

            DocOperationService docOPRServ = new DocOperationService();
            Srv_OperationToDoc optodocSrv = new Srv_OperationToDoc();
            OperationToDoc_DTO optodocItem = optodocSrv.GetOperationToDocByPosID(1, docContentType);
            docOPRServ.Insert(new DocumentOperationDTO
            {
                docID = docID,
                userID = Convert.ToInt32(Session["userID"]),
                fromUserID = Convert.ToInt32(Session["userID"]),
                operationID = optodocItem.fromid,
                operationPos = optodocItem.positionid,
                opercode = optodocItem.opercode,
                isActionConfirmed = 1,
                doDate = DocEntity.docRegDate,
                docDayCount = DocEntity.docDayCount,
                docFinishDate = DocEntity.docFinishDate
            });

            return RedirectToAction("Index", "Document");
        }

        public ActionResult Edit(long id)
        {
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.DocTypes = doctype.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.CtzApp);
            ViewBag.AppealCharacter = new AppealCharacter_Service().GetList();
            ViewBag.AppealType = new AppealTypeService().GetList();
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.User = empServ.GetUserListByPositionStatus();
            ViewBag.ContactType = conType.GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();
            ViewBag.Gender = genderServ.GetList();
            ViewBag.SocialStatus = socialStatusServ.GetList();
            ViewBag.Category = categoryServ.GetList();
            ViewBag.Company = compServ.GetRows();
            return PartialView(ctzServ.GetDocumentByDocID(id));
        }

        [HttpPost]
        public ActionResult Edit(DocumentDTO DocEntity, CitizenDoc_DTO ctzDocEntity)
        {
            doc.Update(DocEntity);
            ctzServ.UpdateByDocID(ctzDocEntity);
            return RedirectToAction("Index", "Document");
        }

        [HttpPost]
        public ActionResult SaveAttachment(DocumentFilesDTO entity)
        {
            var file = System.Web.HttpContext.Current.Request.Files["Files"];
            HttpPostedFileBase filebase = new HttpPostedFileWrapper(file);
            var fileName = entity.dfGUID + "_" + Path.GetFileName(filebase.FileName);
            var path = Path.Combine(Server.MapPath("~/DocumentFiles/"), fileName);
            filebase.SaveAs(path);

            entity.dfName = fileName;
            docFiles.Insert(entity);
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult SaveAttachmentByID(DocumentFilesDTO entity)
        {
            var file = System.Web.HttpContext.Current.Request.Files["Files"];
            HttpPostedFileBase filebase = new HttpPostedFileWrapper(file);
            var fileName = entity.docID + "_" + Path.GetFileName(filebase.FileName);
            var path = Path.Combine(Server.MapPath("~/DocumentFiles/"), fileName);
            filebase.SaveAs(path);
            entity.dfName = fileName;
            docFiles.InsertByID(entity);
            return Json(new { success = true });
        }

        public ActionResult FillCities(long id)
        {
            return Json(regionServ.GetList(id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAttachedFilesByDocID(long id)
        {
            return Json(new { data = docFiles.GetListByDocID(id) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAttachedFiles(string str)
        {
            return Json(new { data = docFiles.GetListByGuid(str) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long docid)
        {
            docFiles.Delete(docid);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAuthorName(int? id)
        {
            if (id != null)
            {
                var data = compServ.GetSingleRecord((int)id);
                if (data != null)
                {
                    return Json(new { success = true, author = data.director }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}