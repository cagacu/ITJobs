//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITJobs.Business.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public long CompanyId { get; set; }
        public long CategoryId { get; set; }
        public long LocationId { get; set; }
        public long JobTypeId { get; set; }
        public System.DateTime PostDateTime { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public byte[] Image { get; set; }
        public long Status { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Status Status1 { get; set; }
    }
}
