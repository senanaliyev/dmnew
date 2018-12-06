using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class DocContentTypeDTO
    {
        public byte id { get; set; }
        public string title { get; set; }
        public byte parentid { get; set; }
    }
}
