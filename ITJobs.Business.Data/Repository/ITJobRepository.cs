using ITJobs.Business.Data.Base;
using ITJobs.Business.Data.Interface;
using ITJobs.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data.Repository
{
    public class ITJobRepository<T,E> : Repository<T,E> 
        where T: class 
        where E : IEntity
    {
        public ITJobRepository(ITJobContext context) : base(context,new QueryManager<T>())
        {
        
        }

    }
}
