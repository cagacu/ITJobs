using ITJobs.Business.Data.Interface;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJobs.Business.Data.Filters;

namespace ITJobs.Business.Data.Repository
{
    internal class QueryManager<T> : IQueryManager<T> where T : class
    {
        private DbContext context;

        public void SetContext(DbContext context)
        {
            this.context = context;
        }

        IQuerySegments<T> IQueryManager<T>.CreateSegment()
        {
            return new QuerySegments<T>();
        }

        public QueryManager()
        { }

        #region ### Apply Methods ###

        IQueryable<T> IQueryManager<T>.ApplyQuerySegments(IQuerySegments<T> segments)
        {
            DbSet<T> dbSet = context.Set<T>();

            IQueryable<T> query = dbSet.AsQueryable();

            if (segments != null)
            {
                ApplyIncludesFields(ref query, segments.IncludeTables);

                ApplyWhereCondition(ref query, segments.WhereCondition);

                //ApplyPageFilter(ref query, pageFilter);

                ApplySelectFields(ref query, segments.SelectFields);
            }
            return query;

        }

        #endregion


        #region ### Core Methods ###

        private void ApplyIncludesFields(ref IQueryable<T> query, string[] includes)
        {
            if(includes != null && includes.Length>0)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
        }

        private void ApplySelectFields(ref IQueryable<T> query, Func<T, T> selectFields)
        {
            if (selectFields != null)
                query = query.Select(selectFields).AsQueryable<T>();
        }

        private void ApplyWhereCondition(ref IQueryable<T> query, Expression<Func<T, bool>> whereCondition)
        {
            if (whereCondition != null)
                query = query.Where(whereCondition);
        }

        #endregion
    }
}
