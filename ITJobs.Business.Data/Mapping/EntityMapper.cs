using ITJobs.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Business.Data.Mapping
{
    public class EntityMapper
    {
        /// <summary>
        /// Map database object to DTO
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static E MapToEntity<E, T>(T source) where E : IEntity
        {
            AutoMapper.Mapper.CreateMap(typeof(T), typeof(E));
            return AutoMapper.Mapper.Map<E>(source);

        }

        /// <summary>
        /// Map DTO to database entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T MapToDatabaseObject<E, T>(E source) where E : IEntity
        {
            AutoMapper.Mapper.CreateMap(typeof(E), typeof(T));
            return AutoMapper.Mapper.Map<E, T>(source);
        }

        /// <summary>
        /// Map database object list to DTO list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<E> MapToEntityList<T, E>(List<T> list) where E : IEntity
        {
            List<E> returnList = new List<E>();
            list.ForEach(delegate(T each)
            {
                returnList.Add(MapToEntity<E, T>(each));
            });
            return returnList;
        }
    }
}
