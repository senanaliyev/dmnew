using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class Custom_DocGetList_DTO
    {
        public long ID { get; set; }
        public string DocRegNo { get; set; }
        public string DocRegDate { get; set; }
        public string DocFinishDate { get; set; }
        public int DocContentTypeID { get; set; }
        public string DocContentTypeTitle { get; set; }
        public string DocTypeTitle { get; set; }
        public int operationID { get; set; }
        public int operationPos { get; set; }
        public string operationTitle { get; set; }
        public long doID { get; set; }
        public string doNote { get; set; }
        public string doDate { get; set; }
        public int fromUserID { get; set; }
        public string fromEmployee { get; set; }
        public string EditRead { get; set; }

        // for DocumentService -> SearchByNameSurname(string name, string surname)
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Fullname { get; set; }


        //public long ID { get; set; }
        //public long doID { get; set; }
        //public string DocRegNo { get; set; }
        //public string DocRegDate { get; set; }
        //public int DocContentTypeID { get; set; }
        //public string DocContentTypeTitle { get; set; }
        //public string DocTypeTitle { get; set; }
        //public string fromUser { get; set; }
        //public int operationID { get; set; }
        //public string operationTitle { get; set; }

    }
}
