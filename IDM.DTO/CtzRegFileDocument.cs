using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class CtzRegFileDocument
    {
        public long docID { get; set; }
        //public int docContentType { get; set; }
        //public int docType { get; set; }
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
        public int citizenshipID { get; set; }
        public string nation { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string appealType { get; set; }
        public string docType { get; set; }
        public int pageCount { get; set; }
        public string gender { get; set; }
        public string socialStatus { get; set; }
        public string category { get; set; }
        //public string fulladdress { get; set; }
    }
}
