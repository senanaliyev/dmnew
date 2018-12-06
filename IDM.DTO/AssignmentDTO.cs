using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
  public  class AssignmentDTO
    {
        public int id { get; set; }
        public int toid { get; set; }
        public int fromid { get; set; }
        public int status { get; set; }
    }
}
