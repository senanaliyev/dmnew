using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class InternalRegFileDoc
    {
        public long docID { get; set; }
        public string docRegNo { get; set; }
        public string docRegDate { get; set; }
        [AllowHtml]
        public string docContent { get; set; }
        [AllowHtml]
        public string docNote { get; set; }
        public string contentTitle { get; set; }
        public string actionTitle { get; set; }

        //---------------Internal_DTO
        public string tematika { get; set; }
        public int internalID { get; set; }
        public string docType { get; set; }
        public int pageCount { get; set; }
    }
}
