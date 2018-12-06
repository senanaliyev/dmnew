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
    public class InternalDocController : Controller
    {
        DocumentService doc = new DocumentService();
        DocumentFilesService docFiles = new DocumentFilesService();
        InternalDocService intServ = new InternalDocService();

        public ActionResult RegViewDocument(long id)
        {
            var data = intServ.GetRegDocumentByDocID(id);
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

        public ActionResult Search()
        {
            return PartialView("Search");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateAttachedDoc(long docid)
        {
            ViewBag.DocTypes = new DocTypeService().GetList();

            //DocContentTypeService docconttype = new DocContentTypeService();
            //ViewBag.DocContentTypes = docconttype.GetListByID((int)Enums.ContentTypes.Internal);

            ViewBag.Office = new Office_Service().GetList();

            ViewBag.ActionType = new ActionTypeService().GetList();

            ViewBag.ContactType = new ContactTypeService().GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.InternalDoc);
            ViewBag.UnID = Guid.NewGuid().ToString();
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.DocID = docid;
            ViewBag.AttachDoc = new AttachDoc().GetList();
            return PartialView("_CreateAttachedDoc");
        }
        public ActionResult Create()
        {
            ViewBag.DocTypes = new DocTypeService().GetList();

            //DocContentTypeService docconttype = new DocContentTypeService();
            //ViewBag.DocContentTypes = docconttype.GetListByID((int)Enums.ContentTypes.Internal);

            ViewBag.Office = new Office_Service().GetList();

            ViewBag.ActionType = new ActionTypeService().GetList();

            ViewBag.ContactType = new ContactTypeService().GetList();

            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.InternalDoc);
            ViewBag.UnID = Guid.NewGuid().ToString();
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
        [ValidateInput(false)]
        public ActionResult Create(DocumentDTO DocEntity, InternalDocDTO intDocEntity, string dfGUID)
        {
            DocEntity.docContentType = (int)Enums.ContentTypes.InternalDoc;

            long docID = doc.Insert(DocEntity);
            intDocEntity.docID = docID;

            new InternalDocService().Insert(intDocEntity);

            new AttachFileTypeService().UpdateDocID(docID, dfGUID);
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

            return RedirectToAction("Index", "Document");
        }
        public ActionResult Edit(long id)
        {
            ViewBag.DocTypes = new DocTypeService().GetList();
            ViewBag.Office = new Office_Service().GetList();
            ViewBag.ActionType = new ActionTypeService().GetList();
            ViewBag.ContactType = new ContactTypeService().GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.InternalDoc);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.AttachDoc = new AttachDoc().GetList();
            return PartialView(new InternalDocService().GetDocumentByID(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DocumentDTO DocEntity, InternalDocDTO intDocEntity)
        {
            new DocumentService().Update(DocEntity);
            new InternalDocService().Update(intDocEntity);
            return RedirectToAction("Index", "Document");
        }
        public JsonResult Delete(long docid)
        {
            docFiles.Delete(docid);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchDocument(string docregno)
        {
            return Json(new { data = doc.SearchByDocNo(docregno) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAttachedFiles(string str)
        {
            return Json(new { data = docFiles.GetListByGuid(str) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAttachedFilesByDocID(long id)
        {
            return Json(new { data = docFiles.GetListByDocID(id) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillOrganizations(int id)
        {
            Organization_Service org = new Organization_Service();
            return Json(org.GetList(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
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
        [ValidateInput(false)]
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

        public ActionResult Attachment()
        {
            AttachFileTypeService attFileType = new AttachFileTypeService();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.InternalDoc);
            return PartialView("_Attachment");
        }
    }
}