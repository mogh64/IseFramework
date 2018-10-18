// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
//using AutoMapper;
using ISE.Framework.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace ISE.Framework.Common.CommonBase
{
    public static class DtoAssembler<TSource, TDestination> where TSource:BaseDto 
        where TDestination:BaseDto
    {
        public static void MapProperty(TSource entity, TDestination destination,string propertyName)
        {
            EntityAssembler<TSource, TDestination>.MapProperty(entity, destination, propertyName);            
        }
        public static void MapObject(TSource entity, TDestination destination)
        {
            EntityAssembler<TSource, TDestination>.MapObject(entity, destination);
            destination.SetResponse(entity.Response);
        }

        public static TDestination MapObject(TSource entity)
        {
           TDestination dentity =  EntityAssembler<TSource, TDestination>.MapObject(entity);
           dentity.SetResponse(entity.Response);
           return dentity;
        }

        public static List<TDestination> MapList(List<TSource> entities)
        {           
           List<TDestination> dentityList = new List<TDestination>();
           foreach (var entity in entities)
           {
               TDestination dentity = EntityAssembler<TSource, TDestination>.MapObject(entity);
               dentity.SetResponse(entity.Response);
               dentityList.Add(dentity);
           }
           return dentityList;
        }       
        
    }
}
