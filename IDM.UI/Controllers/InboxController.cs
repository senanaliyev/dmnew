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
    public class InboxController : Controller
    {
        // GET: Inbox
        public ActionResult Index()
        {
            return View();
        }
    }
}