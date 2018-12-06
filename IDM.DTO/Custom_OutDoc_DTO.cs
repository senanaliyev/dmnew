using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class Custom_OutDoc_DTO
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
        public bool docInCharge { get; set; }

        //----------------CitizenDoc_DTO
        public string name { get; set; }
        public string surname { get; set; }
        public string middlename { get; set; }
        public int countryID { get; set; }
        public int cityID { get; set; }
        public int townID { get; set; }
        public string fulladdress { get; set; }
        public string voen { get; set; }
        public int tematikaID { get; set; }
        public string relatedDocNo { get; set; }
        public string relatedDocRegDate { get; set; }
        public int officeID { get; set; }
        public int organID { get; set; }
    }
}
