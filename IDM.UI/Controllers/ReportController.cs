using IDM.UI.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDM.Service;

namespace IDM.UI.Controllers
{
    [Authorize]
    [MyActionFilter]
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult icraolunmamish()
        {
            return PartialView("_icraolunmamish", new rpt_Raporlar_Srv().IcraOlunmamiw_GetList());
        }
        public ActionResult pammnk()
        {
            return PartialView("_pammnk");
        }

        public ActionResult strkuzresened()
        {
            return PartialView("_strkuzresened", new rpt_Raporlar_Srv().StrukturUzre_GetList(Convert.ToInt32(Session["userID"])));
        }

        public ActionResult vaxtikecmissened()
        {
            return PartialView("_vaxtikecmissened");
        }

        public ActionResult tapgosmektub()
        {
            return PartialView("_tapgosmektub", new rpt_Raporlar_Srv().TapshiriqveGosterish_GetList());
        }

        public ActionResult vtnqebulhesab()
        {
            return PartialView("_vtnqebulhesab", new rpt_Raporlar_Srv().VetendashMuracietleri_GetList((int)Enums.ContentTypes.CtzApp));
        }
        public ActionResult dxlolansenedler()
        {
            return PartialView("_dxlolansenedler", new rpt_Raporlar_Srv().DaxilOlanSened_GetList((int)Enums.ContentTypes.CtzApp, (int)Enums.ContentTypes.ServDoc));
        }

        public ActionResult dxlolansenednzrt()
        {
            return PartialView("_dxlolansenednzrt");
        }

        public ActionResult icrasenedhesab()
        {
            return PartialView("_icrasenedhesab", new rpt_Raporlar_Srv().IcraOlunmush_GetList());
        }

        public ActionResult snddovrhesab()
        {
            return PartialView("_snddovrhesab");
        }

        public ActionResult shikayet()
        {
            return PartialView("_shikayet", new rpt_Raporlar_Srv().Shikayetler_GetList());
        }

        public ActionResult shikayetsayi()
        {
            return PartialView("_shikayetsayi");
        }

        public ActionResult xrcsndhesab()
        {
            return PartialView("_xrcsndhesab", new rpt_Raporlar_Srv().XaricOlanSened_GetList((int)Enums.ContentTypes.OutDoc));
        }
    }
}