using ITJobs.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Common.Entities
{
    public class JobEntity : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ContactInfo { get; set; }
        public long CompanyId { get; set; }
        public long CategoryId { get; set; }
        public long LocationId { get; set; }
        public long JobTypeId { get; set; }
        public DateTime PostDateTime { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public CategoryEntity Category { get; set; }
        public CompanyEntity Company { get; set; }
        public JobTypeEntity JobType { get; set; }
        public LocationEntity Location { get; set; }
    }
}
