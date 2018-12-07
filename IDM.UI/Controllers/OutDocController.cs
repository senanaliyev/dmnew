using IDM.DTO;
using IDM.Service;
using IDM.UI.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDM.UI.Controllers
{
    [Authorize]
    [MyActionFilter]
    public class OutDocController : Controller
    {
        DocumentFilesService docFilesServ = new DocumentFilesService();
        DocTypeService docTypeServ = new DocTypeService();
        Office_Service officeServ = new Office_Service();
        ContactTypeService conTypeServ = new ContactTypeService();
        AttachFileTypeService attFileTypeServ = new AttachFileTypeService();
        OutDoc_Service outDocServ = new OutDoc_Service();
        DocumentService doc = new DocumentService();
        Region_Service regionServ = new Region_Service();
        OutDocToOrgan_Service ODTOServ = new OutDocToOrgan_Service();

        public ActionResult CreateAttachedDoc(long docid)
        {
            ViewBag.DocTypes = docTypeServ.GetList();
            ViewBag.Office = officeServ.GetList();
            ViewBag.ContactType = conTypeServ.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.OutDoc);
            ViewBag.UnID = Guid.NewGuid().ToString();
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();
            ViewBag.DocID = docid;
            return PartialView("_CreateAttachedDoc");
        }

        public ActionResult RegViewDocument(long id)
        {
            var data = outDocServ.GetRegDocumentByDocID(id);
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

        // GET: OutDoc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.DocTypes = docTypeServ.GetList();
            ViewBag.Office = officeServ.GetList();
            ViewBag.ContactType = conTypeServ.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.OutDoc);
            ViewBag.UnID = Guid.NewGuid().ToString();
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();


            //EmployeeService emp = new EmployeeService();
            //ViewBag.Employees = new SelectList((from e in emp.GetList()
            //                                    select new
            //                                    {
            //                                        id = e.empID,
            //                                        title = e.empName + " " + e.empSurname
            //                                    }), "id", "title");
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(DocumentDTO DocEntity, OutDoc_DTO outDocEntity, string dfGUID)
        {
            DocEntity.docContentType = (int)Enums.ContentTypes.OutDoc;

            long docID = doc.Insert(DocEntity);
            outDocEntity.docID = docID;

            outDocServ.Insert(outDocEntity);

            //update DocID by GUID on submit
            AttachFileTypeService attFiles = new AttachFileTypeService();
            attFiles.UpdateDocID(docID, dfGUID);

            //update DocID by GUID on submit
            ODTOServ.UpdateDocID(docID, dfGUID);


            OperationToDoc_DTO optodocItem = new Srv_OperationToDoc().GetOperationToDocByPosID(1, DocEntity.docContentType);
            new DocOperationService().Insert(new DocumentOperationDTO
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

            //DocOperationService docOPRServ = new DocOperationService();
            //docOPRServ.Insert(new DocumentOperationDTO
            //{
            //    docID = docID,
            //    userID = Convert.ToInt32(Session["userID"]),
            //    fromUserID = Convert.ToInt32(Session["userID"]),
            //    operationID = 0,
            //    isActionConfirmed = 1,
            //    doDate = DocEntity.docRegDate
            //});

            return RedirectToAction("Index", "Document");
        }

        public ActionResult Edit(long id)
        {
            ViewBag.DocTypes = docTypeServ.GetList();
            ViewBag.Office = officeServ.GetList();
            ViewBag.ContactType = conTypeServ.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.OutDoc);
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();

            //EmployeeService emp = new EmployeeService();
            //ViewBag.Employees = new SelectList((from e in emp.GetList()
            //                                    select new
            //                                    {
            //                                        id = e.empID,
            //                                        title = e.empName + " " + e.empSurname
            //                                    }), "id", "title");
            return PartialView(outDocServ.GetDocumentByDocID(id));
        }

        [HttpPost]
        public ActionResult Edit(DocumentDTO DocEntity, OutDoc_DTO outDocEntity)
        {
            doc.Update(DocEntity);
            outDocServ.UpdateByDocID(outDocEntity);
            return RedirectToAction("Index", "Document");
        }
        public ActionResult Read(long id)
        {
            ViewBag.DocTypes = docTypeServ.GetList();
            ViewBag.Office = officeServ.GetList();
            ViewBag.ContactType = conTypeServ.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.OutDoc);
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();

            //EmployeeService emp = new EmployeeService();
            //ViewBag.Employees = new SelectList((from e in emp.GetList()
            //                                    select new
            //                                    {
            //                                        id = e.empID,
            //                                        title = e.empName + " " + e.empSurname
            //                                    }), "id", "title");
            return PartialView(outDocServ.GetDocumentByDocID(id));
        }
        public ActionResult FillCities(long id)
        {
            return Json(regionServ.GetList(id), JsonRequestBehavior.AllowGet);
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
            docFilesServ.Insert(entity);
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult AddOrganization(OutDocToOrgan_DTO entity)
        {
            ODTOServ.Insert(entity);
            return Json(new { success = true });
        }
        public ActionResult GetOrganization(string str, long? docid)
        {
            return Json(new { data = ODTOServ.GetList(str, docid) }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteOrganization(long did)
        {
            if (ODTOServ.Delete(did) == 1)
            {
                return Json(new { mesaj = "Silindi." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { mesaj = "Xəta baş verdi!" }, JsonRequestBehavior.AllowGet);
            }
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
            docFilesServ.InsertByID(entity);
            return Json(new { success = true });
        }

        public ActionResult GetAttachedFilesByDocID(long id)
        {
            return Json(new { data = docFilesServ.GetListByDocID(id) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAttachedFiles(string str)
        {
            return Json(new { data = docFilesServ.GetListByGuid(str) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long docid)
        {
            docFilesServ.Delete(docid);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillOrganizations(int id)
        {
            Organization_Service organization = new Organization_Service();
            return Json(organization.GetList(id), JsonRequestBehavior.AllowGet);
        }
    }
}