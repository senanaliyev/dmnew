using IDM.DTO;
using IDM.Service;
using IDM.UI.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDM.UI.Controllers
{

    [Authorize]
    [MyActionFilter]
    public class PopUpParams
    {
        public long DocID { get; set; }
        public int DocTypeID { get; set; }
        public long DoID { get; set; }
        public string FinishDate { get; set; }
        public int FromUser { get; set; }
    }
    public class GeneralController : Controller
    {
        DocOperationService docOpServ = new DocOperationService();
        //Melumat ucun ver -> Taniw oldum
        public ActionResult gnl_muv_tanisoldum_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_gnl_muv_tanisoldum_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }
        //Icra ucun verme -> Icra muddetini uzat imtina
        public ActionResult gnl_imu_muddetiuzatimtina_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            ViewBag.Delay = new DocOperationService().GetOperationDelay(doid);
            return PartialView("_gnl_imu_muddetiuzatimtina_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }
        //Icra ucun verme -> Icra muddetini uzat sorgu
        public ActionResult gnl_imu_muddetiuzat_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_gnl_imu_muddetiuzat_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }
        //Icra ucun verme -> Icra muddetini uzat tesdiq
        public ActionResult gnl_imu_muddetiuzattesdiq_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            ViewBag.Delay = new DocOperationService().GetOperationDelay(doid);
            return PartialView("_gnl_imu_muddetiuzattesdiq_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }
        public ActionResult gnl_iot_tesdiqet_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_gnl_iot_tesdiqet_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }
        //Icra ucun ver -> Geri qaytar
        public ActionResult gnl_iuv_geriqaytar_modal(long documid, int documtypeid, long doid)
        {
            return PartialView("_gnl_iuv_geriqaytar_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        }

        //Icra ucun ver -> Icra etdim
        public ActionResult gnl_iuv_icaretdim_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_gnl_iuv_icaretdim_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }

        //Viza ucun ver -> Viza ver
        public ActionResult gnl_vuv_vizaver_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_gnl_vuv_vizaver_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }

        //Viza ucun ver -> Imtina
        public ActionResult gnl_vuv_imtina_modal(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        {
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_gnl_vuv_imtina_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        }

        public ActionResult gnl_qeyd_modal(long documid, int documtypeid, long doid)
        {
            return PartialView("_gnl_qeyd_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        }
        //teqdiq ucun gonder -> Geri qaytar
        public ActionResult gnl_tug_geriqaytar_modal(long documid, int documtypeid, long doid)
        {
            return PartialView("_gnl_tug_geriqaytar_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        }
        //teqdiq ucun gonder -> Tesdiq et
        public ActionResult gnl_tug_tesdiqet_modal(long documid, int documtypeid, long doid)
        {
            return PartialView("_gnl_tug_tesdiqet_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        }
        //Derkenar ucun ver -> Derkenar ver
        public ActionResult gnl_duv_derkenarver_modal(long documid, int documtypeid, long doid, string finishdate)
        {
            ViewBag.TemplateText = new TemplateText_Service().GetList();
            return PartialView("_gnl_duv_derkenarver_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate });
        }
        //Derkenar ucun ver -> Geri qaytar
        public ActionResult gnl_duv_geriqaytar_modal(long documid, int documtypeid, long doid)
        {
            return PartialView("_gnl_duv_geriqaytar_modal", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IcraMuddetUzatTesdiq(DocumentOperationDTO entity)
        {
            //entity.operationPos = new Srv_OperationToDoc().GetOperationToDocByOprID(21, 3).positionid;
            OperationToDoc_DTO OperToDocObj = new Srv_OperationToDoc().GetOperationToDocByPosID(6, entity.docContentType);
            entity.fromUserID = Convert.ToInt32(Session["userID"]);
            entity.operationID = OperToDocObj.fromid;
            entity.operationPos = OperToDocObj.positionid;
            entity.opercode = OperToDocObj.opercode;
            entity.isActionConfirmed = 1;
            entity.isActionCompleted = 1;
            entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
            docOpServ.Insert(entity);
            new DocOperationService().CompleteOperation(entity.fromDoID, null, null);
            new DocOperationService().ChangeDocumentFinishDate(entity);
            return Json(Url.Action("Index", "Document"));
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IcraMuddetUzatSorgu(DocumentOperationDTO entity)
        {
            //entity.operationPos = new Srv_OperationToDoc().GetOperationToDocByPosID(7, entity.docContentType).positionid;
            OperationToDoc_DTO OperToDocObj = new Srv_OperationToDoc().GetOperationToDocByPosID(6, entity.docContentType);
            entity.fromUserID = Convert.ToInt32(Session["userID"]);
            entity.operationID = OperToDocObj.fromid;
            entity.operationPos = OperToDocObj.positionid;
            entity.opercode = OperToDocObj.opercode;
            entity.isActionConfirmed = 1;
            entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
            docOpServ.Insert(entity);
            //new DocOperationService().CompleteOperation(entity.fromDoID);
            return Json(Url.Action("Index", "Document"));
        }

        public JsonResult CheckOperation(long docid)
        {
            if (new Srv_CheckOperation().CheckOperation(docid).Count() > 0)
            {
                return Json(new { success = true, mesaj = "Viza verilmədiyi üçün icra edə bilməzsiniz!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReturnOperation(long doid, string donote)
        {
            docOpServ.ReturnOperation(doid, donote);
            return Json(Url.Action("Index", "Document"));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IcraniOlunaniTesdiqEt(DocumentOperationDTO entity)
        {
            OperationToDoc_DTO OperToDocObj = new Srv_OperationToDoc().GetOperationToDocByPosID(7, entity.docContentType);
            entity.operationID = OperToDocObj.fromid;
            entity.operationPos = OperToDocObj.positionid;
            entity.opercode = OperToDocObj.opercode;
            entity.fromUserID = Convert.ToInt32(Session["userID"]);
            entity.isActionConfirmed = 1;
            entity.isActionCompleted = 1;
            entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
            docOpServ.Insert(entity);
            new DocOperationService().CompleteOperation(entity.fromDoID, null, null);
            //new DocOperationService().ChangeDocumentFinishDate(entity);
            new DocumentService().CompleteDocument(entity.docID);
            return Json(Url.Action("Index", "Document"));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IcraEtdimSorgu(DocumentOperationDTO entity)
        {
            OperationToDoc_DTO OperToDocObj = new Srv_OperationToDoc().GetOperationToDocByPosID(7, entity.docContentType);
            entity.operationID = OperToDocObj.fromid;
            entity.operationPos = OperToDocObj.positionid;
            entity.opercode = OperToDocObj.opercode;
            entity.fromUserID = Convert.ToInt32(Session["userID"]);
            entity.isActionConfirmed = 1;
            entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
            docOpServ.Insert(entity);
            new DocOperationService().CompleteOperation(entity.fromDoID, null, null);
            //new DocOperationService().ChangeDocumentFinishDate(entity);
            return Json(Url.Action("Index", "Document"));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CompleteOperation(long doid, string donote, string opercode)
        {
            docOpServ.CompleteOperation(doid, donote, opercode);
            return Json(Url.Action("Index", "Document"));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DerkenarVer(long doid, string donote, string opercode, long docid, string docfinishdate)
        {
            docOpServ.CompleteOperation(doid, donote, opercode);
            new DocOperationService().ChangeDocumentFinishDate(docid, 0, docfinishdate);
            return Json(Url.Action("Index", "Document"));
        }

        [HttpPost]
        public ActionResult AddOperation(DocumentOperationDTO entity)
        {
            OperationToDoc_DTO OperToDocObj = new Srv_OperationToDoc().GetOperationToDocByOprID(entity.operationID, entity.docContentType);
            entity.operationPos = OperToDocObj.positionid;
            entity.opercode = OperToDocObj.opercode;
            entity.fromUserID = Convert.ToInt32(Session["userID"]);
            entity.isActionConfirmed = 0;
            entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
            docOpServ.Insert(entity);
            return Json(new { success = true });
        }
    }
}