using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class ServiceRegFileDocument
    {
        public long docID { get; set; }
        public string docRegNo { get; set; }
        public string docRegDate { get; set; }
        [AllowHtml]
        public string docContent { get; set; }
        [AllowHtml]
        public string docNote { get; set; }

        //----------------CitizenDoc_DTO
        public string tematika { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string middlename { get; set; }
        public int serviceDocID { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string appealType { get; set; }
        public string docType { get; set; }
        public int pageCount { get; set; }
    }
}
