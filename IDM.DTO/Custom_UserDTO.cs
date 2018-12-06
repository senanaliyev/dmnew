using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
   public class Custom_UserDTO
    {
        //-----------User Properties
        public int usrID { get; set; }
        public string usrName { get; set; }
        public string usrPassword { get; set; }
        public Nullable<bool> isActive { get; set; }
        //-----------Employee Properties
        public int empID { get; set; }
        public string empName { get; set; }
        public string empSurname { get; set; }
        public string empFullName { get; set; }
        public string empMiddleName { get; set; }
        public string empMail { get; set; }
        public string empPhone { get; set; }
        public string structureTitle { get; set; }
        public string positionTitle { get; set; }

    }
}
