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
    public class ServDocController : Controller
    {
        // GET: ServDoc
        DocTypeService doctype = new DocTypeService();
        Office_Service office = new Office_Service();
        ActionTypeService actType = new ActionTypeService();
        ContactTypeService conType = new ContactTypeService();
        AttachFileTypeService attFileType = new AttachFileTypeService();
        //DocOperationService docOPRServ = new DocOperationService();
        DocumentFilesService docFiles = new DocumentFilesService();
        ServiceDocumentService servDocServ = new ServiceDocumentService();
        ServiceDocSender_Service servDocSender = new ServiceDocSender_Service();
        ServDocAddress_Service servAddrServ = new ServDocAddress_Service();
        Region_Service regionServ = new Region_Service();
        EmployeeService empServ = new EmployeeService();

        public ActionResult RegViewDocument(long id)
        {
            var data = servDocServ.GetRegDocumentByDocID(id);
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.DocTypes = doctype.GetList();
            ViewBag.Office = office.GetList();
            ViewBag.ActionType = actType.GetList();
            ViewBag.ContactType = conType.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.ServDoc);
            ViewBag.AppealType = new AppealTypeService().GetList();
            ViewBag.UnID = Guid.NewGuid().ToString();
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.User = empServ.GetUserListByPositionStatus();
            ViewBag.AttachDoc = new AttachDoc().GetList();
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DocumentDTO DocEntity, ServiceDocumentDTO servDocEntity, ServDocSender_DTO senderEntity, ServDocAddress_DTO addressEntity, string dfGUID)
        {
            DocEntity.docContentType = (int)Enums.ContentTypes.ServDoc;
            DocumentService doc = new DocumentService();
            long docID = doc.Insert(DocEntity);
            servDocEntity.docID = senderEntity.docID = addressEntity.docID = docID;
            servDocServ.Insert(servDocEntity);
            servDocSender.Insert(senderEntity);
            servAddrServ.Insert(addressEntity);

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
            //docOPRServ.Insert(new DocumentOperationDTO
            //{
            //    docID = docID,
            //    userID = Convert.ToInt32(Session["userID"]),
            //    fromUserID = Convert.ToInt32(Session["userID"]),
            //    operationID = 0,
            //    isActionConfirmed = 1,
            //    doDate = DocEntity.docRegDate
            //});
            attFileType.UpdateDocID(docID, dfGUID);
            return RedirectToAction("Index", "Document");
        }

        public ActionResult Edit(long id)
        {
            ViewBag.DocTypes = doctype.GetList();
            ViewBag.Office = office.GetList();
            ViewBag.ActionType = actType.GetList();
            ViewBag.ContactType = conType.GetList();
            ViewBag.AttachFileTypes = new AttachFileTypeService().GetList((int)Enums.ContentTypes.ServDoc);
            ViewBag.AppealType = new AppealTypeService().GetList();
            ServiceDocumentService servDoc = new ServiceDocumentService();
            ViewBag.Region = regionServ.GetList(0);
            ViewBag.Tematika = new Srv_Tematika().GetList();
            ViewBag.User = empServ.GetUserListByPositionStatus();
            ViewBag.AttachDoc = new AttachDoc().GetList();
            return PartialView(servDoc.GetDocumentByID(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DocumentDTO DocEntity, ServiceDocumentDTO servDocEntity, ServDocSender_DTO senderEntity, ServDocAddress_DTO addressEntity, DocumentOperationDTO oprEntity)
        {
            DocumentService doc = new DocumentService();
            doc.Update(DocEntity);
            servDocServ.Update(servDocEntity);
            servDocSender.Update(senderEntity);
            servAddrServ.Update(addressEntity);
            //if (oprEntity.doResponseID > 0)
            //{
            //    docOPRServ.Update(oprEntity);
            //}
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

        public JsonResult FillOrganizations(int id)
        {
            Organization_Service organization = new Organization_Service();
            return Json(organization.GetList(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult FillCities(long id)
        {
            return Json(regionServ.GetList(id), JsonRequestBehavior.AllowGet);
        }
    }
}