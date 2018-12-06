using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class Custom_DocServiceDTO
    {
        public long docID { get; set; }
        public int docContentType { get; set; }
        public int docType { get; set; }
        public string docRegNo { get; set; }
        public string docRegDate { get; set; }
        public int docDayCount { get; set; }
        public string docFinishDate { get; set; }
        [AllowHtml]
        public string docContent { get; set; }
        [AllowHtml]
        public string docNote { get; set; }
        //---------------------------------------
        public long sdID { get; set; }
        public string sdEntryNo { get; set; }
        public string sdEntryDate { get; set; }
        public int appealTypeID { get; set; }
        public string relatedDocNo { get; set; }
        public string relatedDocRegDate { get; set; }
        public int officeID { get; set; }
        public int organID { get; set; }
        public int contactTypeID { get; set; }
        public int tematikaID { get; set; }
        //----------------------------------------
        public long senderID { get; set; }
        public string senderName { get; set; }
        public string senderSurname { get; set; }
        public string senderMiddlename { get; set; }
        //------------------------------
        public int countryID { get; set; }
        public int cityID { get; set; }
        public int townID { get; set; }
        public string adrFullAddress { get; set; }
        public string adrFIN { get; set; }
        public int userID { get; set; }
        //------------------------------
    }
}
