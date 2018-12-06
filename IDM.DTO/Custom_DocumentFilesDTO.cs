using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.DTO
{
  public  class Custom_DocumentFilesDTO
    {
        public long dfID { get; set; }
        public Nullable<long> docID { get; set; }
        public Nullable<byte> attFileTypeID { get; set; }
        public string attFileTypeTitle { get; set; }
        public int dfTitle { get; set; }
        public string dfTitleDesc { get; set; }
        public string dfPageCount { get; set; }
        public string dfName { get; set; }
        public string dfContent { get; set; }
        public string dfGUID { get; set; }
        public byte dfStatus { get; set; }
    }
}
