using ITJobs.Business.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data.Filters
{
    internal class QuerySegments<T> : IQuerySegments<T> where T : class
    {
        Expression<Func<T, bool>> whereCondition;
        Func<T, T> selectFields;
        string[] includeTables;

        Expression<Func<T, bool>> IQuerySegments<T>.WhereCondition { get { return whereCondition; } set { whereCondition = value; } }

        Func<T, T> IQuerySegments<T>.SelectFields { get { return selectFields; } set { selectFields = value; } }
        
        public string[] IncludeTables
        {
            get
            {
                return includeTables;
            }
            set
            {
                includeTables = value;
            }
        }
    }
}
