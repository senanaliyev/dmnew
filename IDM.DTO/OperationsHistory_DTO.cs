using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class OperationsHistory_DTO
    {
        public string docRegNo { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Operation { get; set; }
        public string doDate { get; set; }
    }
}
