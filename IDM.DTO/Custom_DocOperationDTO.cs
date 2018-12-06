using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
  public  class Custom_DocOperationDTO
    {
        public long doID { get; set; }
        public long docID { get; set; }
        public int userID { get; set; }
        public string usrName { get; set; }
        public string NameSurname { get; set; }
        public int operationID { get; set; }
        public string conTypeTitle { get; set; }
        [AllowHtml]
        public string doNote { get; set; }
        public int fromUserID { get; set; }
        public DateTime doDate { get; set; }
        public int doStatus { get; set; }
    }
}
