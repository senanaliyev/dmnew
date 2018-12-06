using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
   public class UserDTO
    {
        public int usrID { get; set; }
        [Required(ErrorMessage = "İstifadəçi adını daxil edin!")]
        public string usrName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Şifrəni daxil edin!")]
        public string usrPassword { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
