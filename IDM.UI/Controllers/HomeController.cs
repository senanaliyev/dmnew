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
    public class HomeController : Controller
    {
        DocumentService document = new DocumentService();
        // GET: Home
        public ActionResult Index()
        {
            return View(document.GetList(Convert.ToInt32(Session["userID"])));
        }

        [ChildActionOnly]
        public PartialViewResult TopMenu()
        {
            return PartialView("_TopMenu", new Srv_Permission().GetList(Convert.ToInt32(Session["userID"])));
        }
    }
}