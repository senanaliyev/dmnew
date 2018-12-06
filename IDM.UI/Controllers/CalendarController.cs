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
    public class CalendarController : Controller
    {
        Srv_Calendar calendarServ = new Srv_Calendar();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", calendarServ.GetSingleRecord(id));
        }
        public ActionResult GetTableRows()
        {
            return Json(new { data = calendarServ.GetRows() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveRecord(Calendar_DTO entity)
        {
            if (ModelState.IsValid)
            {
                calendarServ.Insert(entity);
                return Json(new { success = true, mesaj = "Əlavə olundu" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, mesaj = "Məlumatları doldurun!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveChanges(Calendar_DTO entity)
        {
            if (ModelState.IsValid)
            {
                calendarServ.Update(entity);
                return Json(new { success = true, mesaj = "Redaktə edildi" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, mesaj = "Məlumatları doldurun!!!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}