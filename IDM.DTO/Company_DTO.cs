using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class Company_DTO
    {
        public int id { get; set; }
        [Required]
        public string companyName { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string fulladdress { get; set; }
    }
}
