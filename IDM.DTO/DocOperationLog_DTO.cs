using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
 public   class DocOperationLog_DTO
    {
        public long dologID { get; set; }
        public long docID { get; set; }
        public int docContentType { get; set; }
        public int userID { get; set; }
        public int operationID { get; set; }
        public string dologdate { get; set; }

    }
}
