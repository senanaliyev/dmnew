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
    public class RoleController : Controller
    {

        UserRoleService role = new UserRoleService();
        public ActionResult Index()
        {
            return View(role.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleDTO entity)
        {
            role.Insert(entity);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return PartialView("Edit", role.GetListByID(id));
        }

        [HttpPost]
        public ActionResult Edit(RoleDTO entity)
        {
            role.Update(entity);
            return RedirectToAction("Index");
        }
    }
}