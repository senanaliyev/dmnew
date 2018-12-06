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
    public class SystemController : Controller
    {
        // GET: System
        System_Service sysServ = new System_Service();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult SaveRecord(string tableName, System_DTO entity)
        {
            if (ModelState.IsValid)
            {
                sysServ.InsertByTableName(tableName, entity);
                return Json(new { mesaj = "Əlavə olundu" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { mesaj = "Məlumatları düzgün doldurun!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveChanges(string tableName, System_DTO entity)
        {
            if (ModelState.IsValid)
            {
                sysServ.UpdateByTableName(tableName, entity);
                return Json(new { mesaj = "Redaktə edildi" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { mesaj = "Məlumatları düzgün doldurun!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(string tableName, int id)
        {
            return PartialView("_Edit", sysServ.GetSingleRecord(tableName, id));
        }

        public ActionResult GetTableRows(string str)
        {
            return Json(new { data = sysServ.GetRowsByTableName(str) }, JsonRequestBehavior.AllowGet);
        }
    }
}