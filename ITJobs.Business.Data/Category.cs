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
    
    public partial class Category
    {
        public Category()
        {
            this.Job = new HashSet<Job>();
        }
    
        public long Id { get; set; }
        public string ResourceKey { get; set; }
    
        public virtual ICollection<Job> Job { get; set; }
    }
}