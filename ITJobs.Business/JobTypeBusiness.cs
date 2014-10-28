using ITJobs.Business.Base;
using ITJobs.Business.Data;
using ITJobs.Business.Data.Repository;
using ITJobs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business
{
    public class JobTypeBusiness : BusinessBase<JobType, JobTypeEntity>
    {
        public List<JobTypeEntity> GetList()
        {
            List<JobTypeEntity> returnList = new List<JobTypeEntity>();
            using (ITJobContext context = new ITJobContext())
            {
                ITJobRepository<JobType, JobTypeEntity> repository = ITJobRepository<JobType, JobTypeEntity>.CreateRepository(context);
                returnList.AddRange(repository.GetEntityList(e => new JobType() { Id = e.Id, ResourceKey = e.ResourceKey }));
            }
            return returnList;
        }
    }
}
