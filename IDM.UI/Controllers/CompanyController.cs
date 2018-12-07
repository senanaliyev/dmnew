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
    public class CompanyController : Controller
    {
        Company_Service companyServ = new Company_Service();
        // GET: Company
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
            return PartialView("_Edit", companyServ.GetSingleRecord(id));
        }

        public ActionResult GetTableRows()
        {
            return Json(new { data = companyServ.GetRows() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveRecord(Company_DTO entity)
        {
            if (ModelState.IsValid)
            {
                companyServ.Insert(entity);
                return Json(new { success = true, mesaj = "Əlavə olundu" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, mesaj = "Məlumatları doldurun!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveChanges(Company_DTO entity)
        {
            if (ModelState.IsValid)
            {
                companyServ.Update(entity);
                return Json(new { success = true, mesaj = "Redaktə edildi" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, mesaj = "Məlumatları doldurun!!!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}