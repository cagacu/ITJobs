using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data
{
    public class ITJobContext : ITJobsEntities, IDisposable
    {

        void IDisposable.Dispose()
        {
            base.Dispose();
        }
    }
}
