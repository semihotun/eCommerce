using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerce.Core.Entities;

namespace Entities.Helpers.AutoMapper
{
    public static class AutoMapperExtension
    {
        //TDestination değer al object döndür  
        //this IQueryable source extension olduğunu belirtir
        public static IQueryable<TDestination> MapTo<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand
        )
        {
            var data = source.ProjectTo<TDestination>(AutoMapperConfig.Get(), null , membersToExpand);

            return data;
        }

        public static T MapTo <T> (this object src)
        {
            IMapper mapper = new Mapper(AutoMapperConfig.Get());
            return (T) mapper.Map(src, src.GetType(), typeof(T));
        }
        public static TDest MapTo<T,TDest>(this T src, TDest data)
        {
            IMapper mapper = new Mapper(AutoMapperConfig.Get());

            return  mapper.Map<T, TDest>(src,data);
        }

        public static T MapTo<T>(this T src, T data )
        {
            IMapper mapper = new Mapper(AutoMapperConfig.Get());
            return mapper.Map<T, T>(data, src);
        }



        //public static TTarget MapTo<TSource, TTarget>(this TSource aSource, TTarget aTarget)
        //{
        //    const BindingFlags flags = BindingFlags.Public |
        //                               BindingFlags.Instance | BindingFlags.NonPublic;
        //    
        //    var srcFields = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
        //        where aProp.CanRead     //check if prop is readable
        //        select new
        //        {
        //            Name = aProp.Name,
        //            Type = Nullable.GetUnderlyingType(aProp.PropertyType) ??
        //                   aProp.PropertyType
        //        }).ToList();
        //    var trgFields = (from PropertyInfo aProp in aTarget.GetType().GetProperties(flags)
        //        where aProp.CanWrite   //check if prop is writeable
        //        select new
        //        {
        //            Name = aProp.Name,
        //            Type = Nullable.GetUnderlyingType(aProp.PropertyType) ??
        //                   aProp.PropertyType
        //        }).ToList();
        //    var commonFields = srcFields.Intersect(trgFields).ToList();
        //    /*assign values*/
        //    foreach (var aField in commonFields)
        //    {
        //        var value = aSource.GetType().GetProperty(aField.Name).GetValue(aSource, null);
        //        PropertyInfo propertyInfos = aTarget.GetType().GetProperty(aField.Name);
        //        propertyInfos.SetValue(aTarget, value, null);
        //    }
        //    return aTarget;
        //}
        //public static TTarget CreateMapped<TSource, TTarget>(this TSource aSource) where TTarget : new()
        //{
        //    return aSource.MapTo(new TTarget());
        //}
    }
}
