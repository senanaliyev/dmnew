using IDM.DTO;
using IDM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IDM.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserDTO entity)
        {
            if (ModelState.IsValid)
            {
                LoginService logServ = new LoginService();
                Custom_UserDTO user = logServ.CheckUser(entity);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.usrName, false);
                    Session["userName"] = user.usrName;
                    Session["userID"] = user.usrID;
                    Session["userFullName"] = user.empName + " " + user.empSurname;
                    return RedirectToAction("Index", "Document");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "İstifadəçi mövcud deyil.");
                }
            }

            return View("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}