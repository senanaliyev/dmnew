//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDM.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Document
    {
        public long docID { get; set; }
        public Nullable<byte> docContentType { get; set; }
        public Nullable<byte> docType { get; set; }
        public string docRegNo { get; set; }
        public Nullable<System.DateTime> docRegDate { get; set; }
        public string docContent { get; set; }
        public string docNote { get; set; }
    }
}
