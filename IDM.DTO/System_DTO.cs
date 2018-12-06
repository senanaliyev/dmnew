using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class System_DTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Başlığı daxil edin!")]
        public string title { get; set; }
        public string code { get; set; }
        public int status { get; set; }
        public string statusDesc { get; set; }
        public string table { get; set; }
    }
}
