using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
   public class ExtendedSearch_DTO
    {
        public string docID { get; set; }
        public string docRegDate { get; set; }
        public string docFinishDate { get; set; }
        public string docContentType { get; set; } //daxili, xidmeti, vetendaw, xaric olan
        public string dcontypeTitle { get; set; }
        public string docType { get; set; }
        public string doctypeTitle { get; set; }
        public string docRegNo { get; set; }
        public string docContent { get; set; }
        public string docNote { get; set; }
        public int folderid { get; set; }
        public string tematikaID { get; set; }
        public string fromUserID { get; set; }
        public string actionTypeID { get; set; }
        public string conTypeID { get; set; }
        public string relatedDocNo { get; set; }
        public string appealTypeID { get; set; }
        public string sdEntryNo { get; set; }
        public string officeID { get; set; }
        public string organID { get; set; }
        public string contactTypeID { get; set; }
        public string appealCharID { get; set; }
        public string docApplyTypeID { get; set; }

    }
}
