using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class OutRegFileDoc
    {
        public long docID { get; set; }
        public string docRegNo { get; set; }
        public string docRegDate { get; set; }
        [AllowHtml]
        public string docContent { get; set; }
        [AllowHtml]
        public string docNote { get; set; }
        public string voen { get; set; }

        //---------------OutDoc_DTO
        public string name { get; set; }
        public string surname { get; set; }
        public string middlename { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string tematika { get; set; }
        public int outDocID { get; set; }
        public string docType { get; set; }
        public int pageCount { get; set; }
    }
}
