using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class EmployeeDTO
    {
        public int empID { get; set; }
        public int usrID { get; set; }
        public string empName { get; set; }
        public string empSurname { get; set; }
        public string empMiddleName { get; set; }
        public string empMail { get; set; }
        public string empPhone { get; set; }
    }
}
