using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class OutDoc_DTO
    {
        public long docID { get; set; }
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
    }
}
