using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data.Interface
{
    internal interface IQueryManager<T>
     where T : class
    {
        void SetContext(System.Data.Entity.DbContext context);
        IQuerySegments<T> CreateSegment();
        System.Linq.IQueryable<T> ApplyQuerySegments(IQuerySegments<T> segments);
    }

    internal interface IQuerySegments<T>
     where T : class
    {
        Expression<Func<T, bool>> WhereCondition { get; set; }
        Func<T, T> SelectFields { get; set; }
        string[] IncludeTables { get; set; }
    }
    
}
