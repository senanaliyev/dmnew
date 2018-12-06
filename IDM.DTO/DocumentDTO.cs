using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IDM.DTO
{
    public class DocumentDTO
    {
        public long docID { get; set; }
        public int docContentType { get; set; }
        public int docType { get; set; }
        [Required(ErrorMessage = "Sənəd nömrəsini daxil edin!")]
        public string docRegNo { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string docRegDate { get; set; }
        public int docDayCount { get; set; }
        public string docFinishDate { get; set; }
        [AllowHtml]
        public string docContent { get; set; }
        [AllowHtml]
        public string docNote { get; set; }
        public bool docInCharge { get; set; }
        public long belongToDoc { get; set; }
    }
}
