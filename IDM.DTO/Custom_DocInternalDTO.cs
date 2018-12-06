using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class Custom_DocInternalDTO
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
        public int actionTypeID { get; set; }
        public string relatedDocNo { get; set; }
        public string relatedDocRegDate { get; set; }
        public int conTypeID { get; set; }
        public int tematikaID { get; set; }
    }
}
