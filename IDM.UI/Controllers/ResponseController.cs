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

    //public class PopUpParams
    //{
    //    public long DocID { get; set; }
    //    public int DocTypeID { get; set; }
    //    public long DoID { get; set; }
    //    public string FinishDate { get; set; }
    //    public int FromUser { get; set; }
    //}

    public class ResponseController : Controller
    {
        DocOperationService docOpServ = new DocOperationService();

        public ActionResult History(long docid)
        {
            return PartialView("_History", docOpServ.GetOperationHistory(docid));
        }



        //public ActionResult tug_tesdiqet(long documid, int documtypeid, long doid)
        //{
        //    return PartialView("tug_tesdiqet", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        //}

        //public ActionResult tug_geri(long documid, int documtypeid, long doid)
        //{
        //    return PartialView("tug_geri", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid });
        //}

        //public ActionResult icra_muddetuzat_sorgu(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        //{
        //    ViewBag.Users = new EmployeeService().GetList();
        //    return PartialView("icra_muddetuzat_sorgu", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        //}

        //public ActionResult icra_icraet(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        //{
        //    ViewBag.Users = new EmployeeService().GetList();
        //    return PartialView("icra_icraet", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        //}

        //public ActionResult icra_muddetuzat_tesdiq(long documid, int documtypeid, long doid, string finishdate, int fromuser)
        //{
        //    ViewBag.Users = new EmployeeService().GetList();
        //    ViewBag.Delay = new DocOperationService().GetOperationDelay(doid);
        //    return PartialView("icra_muddetuzat_tesdiq", new PopUpParams { DocID = documid, DocTypeID = documtypeid, DoID = doid, FinishDate = finishdate, FromUser = fromuser });
        //}



        //[HttpPost]
        //public ActionResult VizayaGonder(DocumentOperationDTO entity)
        //{
        //    entity.operationPos = new Srv_OperationToDoc().GetOperationToDocByOprID(21, 3).positionid;
        //    entity.fromUserID = Convert.ToInt32(Session["userID"]);
        //    entity.isActionConfirmed = 1;
        //    entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    docOpServ.Insert(entity);
        //    //new DocOperationService().CompleteOperation(entity.fromDoID);
        //    return Json(Url.Action("Index", "Document"));
        //}

        //[HttpPost]
        //public ActionResult CompleteOperation(long doid, string opercode)
        //{
        //    docOpServ.CompleteOperation(doid, opercode);
        //    return Json(Url.Action("Index", "Document"));
        //}

        //[HttpPost]
        //public ActionResult ReturnOperation(long doid)
        //{
        //    docOpServ.ReturnOperation(doid);
        //    return Json(Url.Action("Index", "Document"));
        //}



        //[HttpPost]
        //public ActionResult IcraMuddetUzatSorgu(DocumentOperationDTO entity)
        //{
        //    entity.operationPos = new Srv_OperationToDoc().GetOperationToDocByOprID(21, 3).positionid;
        //    entity.fromUserID = Convert.ToInt32(Session["userID"]);
        //    entity.isActionConfirmed = 1;
        //    entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    docOpServ.Insert(entity);
        //    //new DocOperationService().CompleteOperation(entity.fromDoID);
        //    return Json(Url.Action("Index", "Document"));
        //}
        //[HttpPost]
        //public ActionResult IcraMuddetUzatTesdiq(DocumentOperationDTO entity)
        //{
        //    entity.operationPos = new Srv_OperationToDoc().GetOperationToDocByOprID(21, 3).positionid;
        //    entity.fromUserID = Convert.ToInt32(Session["userID"]);
        //    entity.isActionConfirmed = 1;
        //    entity.isActionCompleted = 1;
        //    entity.doDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    docOpServ.Insert(entity);
        //    new DocOperationService().CompleteOperation(entity.fromDoID, null, null);
        //    new DocOperationService().ChangeDocumentFinishDate(entity);
        //    return Json(Url.Action("Index", "Document"));
        //}
        public ActionResult GetAssignedOperations(long id, long doid)
        {
            return Json(new { data = docOpServ.GetOperationList(id, doid) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long doid)
        {
            docOpServ.Delete(doid);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }

}