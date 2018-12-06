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
    public class ExtendedSearchController : Controller
    {
        // GET: ExtendedSearch
        public ActionResult Index()
        {
            return View(new DocumentService().GetList(Convert.ToInt32(Session["userID"])));
        }
    }
}