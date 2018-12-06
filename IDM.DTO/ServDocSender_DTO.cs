using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class ServDocSender_DTO
    {
        public long senderID { get; set; }
        public long docID { get; set; }
        public string senderName { get; set; }
        public string senderSurname { get; set; }
        public string senderMiddlename { get; set; }
    }
}
