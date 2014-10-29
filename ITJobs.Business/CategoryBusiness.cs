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
    public class CategoryBusiness : BusinessBase<Category, CategoryEntity>
    {


        public List<CategoryEntity> GetList()
        {
            List<CategoryEntity> returnList = new List<CategoryEntity>();
            using (ITJobContext context = new ITJobContext())
            {
                ITJobRepository<Category, CategoryEntity> repository = ITJobRepository<Category, CategoryEntity>.CreateRepository(context);
                returnList.AddRange(repository.GetEntityList(e => new Category() { Id = e.Id, ResourceKey = e.ResourceKey }));
            }
            return returnList;
        }





    }
}
