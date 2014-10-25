using ITJobs.Business.Base;
using ITJobs.Business.Data;
using ITJobs.Business.Data.Repository;
using ITJobs.Common.Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJobs.Business.Data.Mapping;

namespace ITJobs.Business
{
    public class JobBusiness : BusinessBase<Job,JobEntity>
    {
        public List<CategoryEntity> GetTypeGroupedJobDetailList()
        {
            List<IGrouping<Category, Job>> jobList = null;
            using(ITJobContext context = new ITJobContext())
            {
                jobList = context.Job.Include("Category").Include("JobType").Include("Location").Include("Company").OrderBy(e => e.PostDateTime).GroupBy(e => e.Category).ToList();
            }

            List<CategoryEntity> returnList = new List<CategoryEntity>();
            IGrouping<Category, Job> eachGroup = null;
            CategoryEntity eachCategory;

            for (int i = 0; i < jobList.Count; i++)
            {
                eachGroup = jobList[i];
                eachCategory = EntityMapper.MapToEntity<CategoryEntity, Category>(eachGroup.Key);
                eachCategory.JobList = EntityMapper.MapToEntityList<Job, JobEntity>(eachGroup.ToList());
                returnList.Add(eachCategory);
            }

            return returnList;
        }

    }
}

