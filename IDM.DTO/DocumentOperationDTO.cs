using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class DocumentOperationDTO
    {
        public long doID { get; set; }
        public long fromDoID { get; set; }
        public long docID { get; set; }
        public int docContentType { get; set; }
        public int userID { get; set; }
        public int fromUserID { get; set; }
        public int operationID { get; set; }
        public int operationPos { get; set; }
        public string opercode { get; set; }
        [AllowHtml]
        public string doNote { get; set; }
        public int isActionConfirmed { get; set; }
        public int isActionCompleted { get; set; }
        public string doDate { get; set; }
        public int docDayCount { get; set; }
        public string docFinishDate { get; set; }
    }
}
