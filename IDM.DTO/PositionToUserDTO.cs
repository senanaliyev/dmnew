using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
  public  class PositionToUserDTO
    {
        public int ptuID { get; set; }
        public int strID { get; set; }
        public string structureTitle { get; set; }
        public int posID { get; set; }
        public string positionTitle { get; set; }
        public int usrID { get; set; }

    }
}
