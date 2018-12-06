using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
   public class InternalDocDTO
    {
        public long intdocID { get; set; }
        public long docID { get; set; }
        public int actionTypeID { get; set; }
        public string relatedDocNo { get; set; }
        public string relatedDocRegDate { get; set; }
        public int conTypeID { get; set; }
        public int tematikaID { get; set; }
    }
}
