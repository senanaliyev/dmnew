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
    public class SearchController : Controller
    {
        DocumentService document = new DocumentService();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Search()
        {
            ViewBag.DocContentType = new Srv_DocContentType().GetList();
            ViewBag.DocTypes = new DocTypeService().GetList();

            ViewBag.ContactType = new ContactTypeService().GetList();

            ViewBag.Tematika = new Srv_Tematika().GetList();

            return PartialView("_Search"/*, document.GetList(Convert.ToInt32(Session["userID"]))*/);
        }

        public ActionResult SearchDocument(ExtendedSearch_DTO entity)
        {
            return Json(new Srv_ExtendedSearch().Search(entity), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchPartial(int id)
        {
            string searchpage = string.Empty;
            switch (id)
            {
                case 1:
                    ViewBag.ActionType = new ActionTypeService().GetList();
                    ViewBag.ContactType = new ContactTypeService().GetList();
                    searchpage = "_daxilisened";
                    break;
                case 2:
                    ViewBag.AppealType = new AppealTypeService().GetList();
                    ViewBag.ContactType = new ContactTypeService().GetList();
                    ViewBag.Office = new Office_Service().GetList();
                    searchpage = "_xidmetisened";
                    break;
                case 3:
                    ViewBag.AppealType = new AppealTypeService().GetList();
                    ViewBag.AppealCharacter = new AppealCharacter_Service().GetList();
                    searchpage = "_vetendashmuracieti";
                    break;
                case 4:
                    ViewBag.Office = new Office_Service().GetList();
                    searchpage = "_xaricolansened";
                    break;
                default:
                    searchpage = "_blankpage";
                    break;
            }


            return PartialView(searchpage);
        }
    }
}