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
    public class AssignmentController : Controller
    {
        Assignment_Service assignServ = new Assignment_Service();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult FillToTables(string table)
        {
            return Json(assignServ.GetToTable(table), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillFromTables(string table)
        {
            return Json(assignServ.GetToTable(table), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillAssignedTables(int toid, string assignTable, string fromTable)
        {
            return Json(assignServ.GetAssigned(toid, assignTable, fromTable), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecord(int id, string assignTable)
        {
            if (assignServ.DeleteAssigned(id, assignTable) == 1)
            {
                return Json(new { mesaj = "Silindi!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { mesaj = "Xəta baş verdi!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveRecord(string assignTable, AssignmentDTO entity)
        {
            if (ModelState.IsValid)
            {
                assignServ.InsertByTableName(assignTable, entity);
                return Json(new { mesaj = "Əlavə olundu" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { mesaj = "Xəta baş verdi!!!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}