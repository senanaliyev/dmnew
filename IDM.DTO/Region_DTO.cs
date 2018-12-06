using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
  public  class Region_DTO
    {
        public long id { get; set; }
        public string title { get; set; }
        public long parentid { get; set; }
    }
}
