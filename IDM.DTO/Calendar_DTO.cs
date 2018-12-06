using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class Calendar_DTO
    {
        public int id { get; set; }
        [Required]
        public string cal_date { get; set; }
        [Required]
        public string cal_enddate { get; set; }
        [Required]
        public string cal_title { get; set; }
    }
}
