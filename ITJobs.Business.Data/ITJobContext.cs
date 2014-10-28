using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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

        public override int SaveChanges()
        {
            var modified = this.ChangeTracker.Entries().Where(e => e.State == System.Data.Entity.EntityState.Modified);

            return base.SaveChanges();
        }
    }
}
