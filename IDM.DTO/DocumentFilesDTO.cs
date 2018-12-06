using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
  public  class DocumentFilesDTO
    {
        public long dfID { get; set; }
        public Nullable<long> docID { get; set; }
        public int attFileTypeID { get; set; }
        public string dfTitle { get; set; }
        public string dfPageCount { get; set; }
        public string dfName { get; set; }
        [AllowHtml]
        public string dfContent { get; set; }
        public string dfGUID { get; set; }
        public int dfStatus { get; set; }
    }
}
