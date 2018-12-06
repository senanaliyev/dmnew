using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO.Report
{
    public class rpt_xaricolansened_DTO
    {
        public long docID { get; set; }
        public string docRegNo { get; set; }
        public string DocContentTypeTitle { get; set; }
        public string docRegDate { get; set; }
        public string DocCreatedBy { get; set; }
        public string docFinishDate { get; set; }
        public string docCompletedOn { get; set; }
        public string docNote { get; set; }
        public string docContent { get; set; }
    }
}
