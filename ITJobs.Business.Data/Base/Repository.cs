using ITJobs.Business.Data.Filters;
using ITJobs.Business.Data.Interface;
using ITJobs.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data.Base
{
    public abstract class Repository<T,E> : IRepository<T,E> 
        where T:class 
        where E : IEntity
    {
        DbContext context;
        IQueryManager<T> queryManager;
        DbSet<T> table = null;

        private Repository() { }

        internal Repository(DbContext context, IQueryManager<T> queryManager)
        {
            this.context = context;
            this.queryManager = queryManager;
            this.queryManager.SetContext(context);
            table = context.Set<T>();
        }

        public IQueryable<T> GetQuery()
        {
            return table.AsQueryable<T>();
        }


        #region ### List ###

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            return Get(whereCondition, null);
        }

        public T Get(Func<T, T> selectFields)
        {
            return Get(null, selectFields);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields)
        {
            IQuerySegments<T> segment = queryManager.CreateSegment();
            segment.SelectFields = selectFields;
            segment.WhereCondition = whereCondition;
            var query = queryManager.ApplyQuerySegments(segment);
            return query.FirstOrDefault();
        }

        public E GetEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            return GetEntity(whereCondition, null);
        }

        public E GetEntity(Func<T, T> selectFields)
        {
            return GetEntity(null, selectFields);
        }

        public E GetEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields)
        {
            T t = Get(whereCondition,selectFields);
            return ITJobs.Business.Data.Mapping.EntityMapper.MapToEntity<E, T>(t);
        }

        public List<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            return GetList(whereCondition, null);
        }

        public List<T> GetList(Func<T, T> selectFields)
        {
            return GetList(null, selectFields);
        }

        public List<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields)
        {
            return GetList(whereCondition, selectFields, null);
        }

        public List<T> GetList(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields, string[] includes)
        {
            IQuerySegments<T> segment = queryManager.CreateSegment();
            segment.SelectFields = selectFields;
            segment.WhereCondition = whereCondition;
            var query = queryManager.ApplyQuerySegments(segment);
            return query.ToList<T>();
        }

        public List<E> GetEntityList(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            return GetEntityList(whereCondition, null);
        }

        public List<E> GetEntityList(Func<T, T> selectFields)
        {
            return GetEntityList(null, selectFields);
        }

        public List<E> GetEntityList(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields)
        {
            List<T> list = GetList(whereCondition, selectFields);
            return ITJobs.Business.Data.Mapping.EntityMapper.MapToEntityList<T,E>(list);
        }

        public long Count()
        {
            return Count(null, null);
        }

        public long Count(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields)
        {
            return GetList(whereCondition,selectFields).Count();
        }

        #endregion

        #region ### Edit ###

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void InsertEntity(E entity)
        {
            T newItem = ITJobs.Business.Data.Mapping.EntityMapper.MapToDatabaseObject<E, T>(entity);
            Insert(newItem);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry<T>(obj).State = EntityState.Modified;
        }

        public void UpdateEntity(E entity)
        {
            T item = ITJobs.Business.Data.Mapping.EntityMapper.MapToDatabaseObject<E, T>(entity);
            Update(item);
        }

        public void DeleteEntity(E item)
        {
            Delete(ITJobs.Business.Data.Mapping.EntityMapper.MapToDatabaseObject<E, T>(item));
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            Delete(table.Find(whereCondition));
        }

        public void Delete(T item)
        {
            table.Remove(item);
        }

        #endregion

        public void Save()
        {
            context.SaveChanges();
        }        
    }
}
