using ITJobs.Common.CustomDataAnnotations;
using ITJobs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITJobs.ViewModels
{
    public class JobViewModel
    {
        public long Id { get; set; }

        [ResourceAttribute("JobTitle")]
        public string Title { get; set; }

        [ResourceAttribute("JobDescription")]
        public string Description { get; set; }

        [ResourceAttribute("JobImagePath")]
        public string ImagePath { get; set; }

        [ResourceAttribute("JobContactInfo")]
        public string ContactInfo { get; set; }

        [ResourceAttribute("JobCompanyId")]
        public long CompanyId { get; set; }

        [ResourceAttribute("JobCategoryId")]
        public long CategoryId { get; set; }

        [ResourceAttribute("JobLocationId")]
        public long LocationId { get; set; }

        [ResourceAttribute("JobJobTypeId")]
        public long JobTypeId { get; set; }

        public DateTime PostDateTime { get; set; }
        
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string JobTypeName { get; set; }
        public string LocationName { get; set; }
    }
}