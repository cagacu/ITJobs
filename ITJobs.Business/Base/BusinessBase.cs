using ITJobs.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Base
{
    public abstract class BusinessBase<T,E> 
        where T:class 
        where E :IEntity
    {
        

    }
}
