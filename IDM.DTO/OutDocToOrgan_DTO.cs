using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
   public class OutDocToOrgan_DTO
    {
        public long id { get; set; }
        public long docID { get; set; }
        public int orgID { get; set; }
        public int incharge { get; set; }
        public string inchargeTitle { get; set; }
        public string orgTitle { get; set; }
        public string guid { get; set; }
    }
}
