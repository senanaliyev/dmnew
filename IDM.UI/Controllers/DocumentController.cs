﻿using IDM.DTO;
using IDM.Service;
using IDM.UI.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDM.UI.Controllers
{
    [Authorize]
    [MyActionFilter]

    public class DocumentController : Controller
    {
        // GET: Document
        DocTypeService docType = new DocTypeService();
        DocumentService document = new DocumentService();
        Office_Service nmc = new Office_Service();
        DocOperationService docOpServ = new DocOperationService();

        public ActionResult MoveToFolder(string documents, int folderid)
        {
            documents = documents.Substring(0, documents.Length - 1);
            var result = documents.Split(',');
            foreach (var docid in result)
            {
                new Srv_DocumentFolder().MoveToFolder(Convert.ToInt64(docid), folderid);
            }
            return Json(new { result = "Redirect", url = Url.Action("Index", "Document") }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateFolder()
        {
            return PartialView("_CreateFolder");
        }
        [HttpPost]
        public ActionResult SaveFolder(DocumentFolder_DTO entity)
        {
            if (ModelState.IsValid)
            {
                entity.usrID = Convert.ToInt32(Session["userID"]);
                new Srv_DocumentFolder().Insert(entity);
                return Json(new { mesaj = "Əlavə olundu" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { mesaj = "Məlumatları düzgün doldurun!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Index()
        {
            ViewBag.Folders = new Srv_DocumentFolder().GetList(Convert.ToInt32(Session["userID"]));
            return View();
            //return View(document.GetList(Convert.ToInt32(Session["userID"])));
        }

        //public ActionResult Inbox(int id)
        //{
        //    return PartialView("_Inbox", document.GetListByTypeID(id, Convert.ToInt32(Session["userID"])));
        //}
        //public ActionResult OperationInbox(int id)
        //{
        //    return PartialView("_Inbox", document.GetListByOperationID(id, Convert.ToInt32(Session["userID"])));
        //}

        //public ActionResult InboxMenu()
        //{
        //    return PartialView("_InboxMenu", ViewBag.OperationsMenu = docOpServ.OperationList());
        //}

        public ActionResult FilterMenu()
        {
            ViewBag.DocContentType = new Srv_DocContentType().GetList();
            ViewBag.DocTypes = new DocTypeService().GetList();
            ViewBag.Users = new EmployeeService().GetList().GroupBy(p => p.usrID).Select(g => g.FirstOrDefault()).ToList();
            ViewBag.Folders = new Srv_DocumentFolder().GetList(Convert.ToInt32(Session["userID"]));
            return PartialView("_FilterMenu");
        }
        public ActionResult DocumentListByFolderName(int folderid)
        {
            return PartialView("_DocumentList", new Srv_DocFolder().FilterByFolderId(folderid, Convert.ToInt32(Session["userID"])));
            //document.GetList(Convert.ToInt32(Session["userID"])));
        }

        public ActionResult DocumentListByOperCode(string operationCode)
        {
            return PartialView("_DocumentList", new Srv_DocFolder().FilterByOperCode(operationCode, Convert.ToInt32(Session["userID"])));
        }

        public ActionResult FilteredList(ExtendedSearch_DTO entity)
        {
            return PartialView("_DocumentList", document.FilterDocumentList(entity, Convert.ToInt32(Session["userID"])));
            //document.GetList(Convert.ToInt32(Session["userID"])));
        }
        public ActionResult DocumentList(ExtendedSearch_DTO entity)
        {
            return PartialView("_DocumentList", document.DocumentFirstLoad(entity, Convert.ToInt32(Session["userID"])));
            //document.GetList(Convert.ToInt32(Session["userID"])));
        }


        //[HttpPost]
        //public ActionResult SaveOperation(DocumentOperationDTO entity)
        //{
        //    entity.fromUserID = Convert.ToInt32(Session["userID"]);
        //    entity.doDate = DateTime.Now.ToString();
        //    entity.doStatus = 1;
        //    docOpServ.Insert(entity);
        //    return Json(new { success = true });
        //}

        [HttpPost]
        public ActionResult LockDocument(long docid)
        {
            document.LockDocument(docid);
            return Json(Url.Action("Index", "Document"));
        }

        //public JsonResult Delete(long doid)
        //{
        //    docOpServ.Delete(doid);
        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult GetAssignedOperations(long id)
        //{
        //    return Json(new { data = docOpServ.GetOperationList(id) }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetOperationResponces(int id)
        {
            OpResponseService operRespoServ = new OpResponseService();
            return Json(operRespoServ.GetListByID(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillUserDDL()
        {
            return Json(new EmployeeService().GetEmployeeList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillOperationDDL(int id, int? operposid, long? doid/*, int docid*/)
        {
            return Json(new DocContentTypeService().GetListByID(id, operposid, doid/*, docid*/), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CalculateEndDate(string date, int daycount)
        {
            List<DateTime> vacations = new Srv_Calendar().GetDaysSeparately();
            DateTime beginDate = Convert.ToDateTime(DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            DayOfWeek day;
            string lastDate = "";
            for (int i = 0; i <= daycount; i++)
            {
                DateTime currentDate = beginDate.AddDays(i);
                day = currentDate.DayOfWeek;
                if ((day != DayOfWeek.Saturday) && (day != DayOfWeek.Sunday))
                {
                    foreach (var item in vacations)
                    {
                        if ((currentDate == item))
                        {
                            daycount += 1;
                        }
                        else
                        {
                            lastDate = currentDate.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {
                    daycount += 1;
                }
            }
            return Json(new { enddate = lastDate }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult FillOperationDDL(int id)
        //{
        //    DocContentTypeService docConTypeServ = new DocContentTypeService();
        //    return Json(docConTypeServ.GetListByID(id), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetAboutDocument(long docID)
        {
            DocumentDTO data = document.GetDocumentByDocID(docID);
            ViewBag.DocumentAbout = data;
            return PartialView("_GetAboutDocument"); ;
        }

    }
}