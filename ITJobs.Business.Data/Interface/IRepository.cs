using ITJobs.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data.Interface
{
    internal interface IRepository<T, E> : IListRepository<T, E>, IEditRepository<T, E> where T:class where E:IEntity
    {

    }

    internal interface IListRepository<T, E> 
        where T : class 
        where E : IEntity
    {
        IQueryable<T> GetQuery();

        T Get(Expression<Func<T, bool>> whereCondition);
        T Get(Func<T, T> selectFields);
        T Get(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields);

        E GetEntity(Expression<Func<T, bool>> whereCondition);
        E GetEntity(Func<T, T> selectFields);
        E GetEntity(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields);

        List<T> GetList(Expression<Func<T, bool>> whereCondition);
        List<T> GetList(Func<T, T> selectFields);
        List<T> GetList(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields);

        List<E> GetEntityList(Expression<Func<T, bool>> whereCondition);
        List<E> GetEntityList(Func<T, T> selectFields);
        List<E> GetEntityList(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields);

        long Count();
        long Count(Expression<Func<T, bool>> whereCondition, Func<T, T> selectFields);

    }

    internal interface IEditRepository<T, E> 
        where T : class 
        where E : IEntity
    {
        void Insert(T obj);
        void InsertEntity(E entity);

        void Update(T obj);
        void UpdateEntity(E obj);
        
        void DeleteEntity(E item);
        void Delete(T item);
        void Delete(Expression<Func<T, bool>> whereCondition);

        void Save();
    }
}
