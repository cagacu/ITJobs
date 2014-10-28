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
    public class LocationBusiness : BusinessBase<Location, LocationEntity>
    {
        public List<LocationEntity> GetList()
        {
            List<LocationEntity> returnList = new List<LocationEntity>();
            using (ITJobContext context = new ITJobContext())
            {
                ITJobRepository<Location, LocationEntity> repository = ITJobRepository<Location, LocationEntity>.CreateRepository(context);
                returnList.AddRange(repository.GetEntityList(e => new Location() { Id = e.Id, ResourceKey = e.ResourceKey }));
            }
            return returnList;
        }
    }
}
