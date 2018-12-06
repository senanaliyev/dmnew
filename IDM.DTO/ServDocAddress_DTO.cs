using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class ServDocAddress_DTO
    {
        public long docID { get; set; }
        public int countryID { get; set; }
        public int cityID { get; set; }
        public int townID { get; set; }
        public string adrFullAddress { get; set; }
        public string adrFIN { get; set; }
    }
}
