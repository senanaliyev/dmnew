using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
    public class ServiceDocumentDTO
    {
        public long sdID { get; set; }
        public long docID { get; set; }
        public string sdEntryNo { get; set; }
        public string sdEntryDate { get; set; }
        public int appealTypeID { get; set; }
        public string relatedDocNo { get; set; }
        public string relatedDocRegDate { get; set; }
        public int officeID { get; set; }
        public int organID { get; set; }
        public int contactTypeID { get; set; }
        public int tematikaID { get; set; }
        public int userID { get; set; }
    }
}
