//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookinigPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class News
    {
        public System.Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Release Date")]
        public System.DateTime ReleaseDate { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
