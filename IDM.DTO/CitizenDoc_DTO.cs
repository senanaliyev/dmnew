using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class CitizenDoc_DTO
    {
        public long id { get; set; }
        public long docID { get; set; }
        public int tematikaID { get; set; }
        public int appealCharID { get; set; }
        public int appealTypeID { get; set; }
        public int docApplyTypeID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string middlename { get; set; }
        public int citizenshipID { get; set; }
        public int nationID { get; set; }
        public int countryID { get; set; }
        public int cityID { get; set; }
        public int townID { get; set; }
        public int categoryID { get; set; }
        public int genderID { get; set; }
        public int socialStatusID { get; set; }
        public string fulladdress { get; set; }
        public string relatedDocNo { get; set; }
        public string relatedDocRegDate { get; set; }
        public int userID { get; set; }

    }
}
