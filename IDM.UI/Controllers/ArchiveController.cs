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
    public class ArchiveController : Controller
    {
        Srv_Archive archiveSrv = new Srv_Archive();

        // GET: Archive
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToArchive(Archive_DTO entity)
        {
            archiveSrv.Insert(entity);
            return Json(new { success = true });
        }

        public ActionResult UnArchivedDocumentList(ExtendedSearch_DTO entity)
        {
            return PartialView("_UnArchivedDocumentList");
            //document.GetList(Convert.ToInt32(Session["userID"])));
        }

        public ActionResult FilteredArchive(Archive_DTO entity)
        {
            return PartialView("_FilteredArchive", archiveSrv.ArchiveFilter(entity, Convert.ToInt32(Session["userID"])));
        }

        public ActionResult GetUnArchivedDocs(Archive_DTO entity)
        {
            return Json(new { data = archiveSrv.UnarchivedDocList(Convert.ToInt32(Session["userID"])) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterArchive()
        {
            ViewBag.DocContentType = new Srv_DocContentType().GetList();
            ViewBag.DocTypes = new DocTypeService().GetList();
            ViewBag.Users = new EmployeeService().GetList();
            return PartialView("_FilterArchive");
        }
    }
}