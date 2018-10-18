// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
//using AutoMapper;
using EmitMapper;
using ISE.Framework.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.CommonBase
{
    public static class EntityAssembler<TSource, TDestination>
    {
        public static void MapProperty(TSource entity, TDestination destination, string propertyName)
        {
            var value = AssemblyReflector.GetValue(entity, propertyName);
            AssemblyReflector.SetValue(destination, propertyName, value);
        }
        public static void MapObject(TSource entity, TDestination destination)
        {
            ObjectMapperManager.DefaultInstance.GetMapper<TSource, TDestination>().Map(entity, destination);
            //Mapper.CreateMap<TSource, TDestination>();
            //Mapper.Map<TSource, TDestination>(entity, destination);
        }

        public static TDestination MapObject(TSource sentity)
        {
            TDestination dentity = ObjectMapperManager.DefaultInstance.GetMapper<TSource, TDestination>().Map(sentity);

            //Mapper.CreateMap<TSource, TDestination>();

            //TDestination dentity = Mapper.Map<TSource, TDestination>(sentity);
            

            return dentity;
        }

        public static List<TDestination> MapList(List<TSource> entities)
        {

            List<TDestination> dentityList = new List<TDestination>();
            
            foreach (TSource entity in entities)
            {
                dentityList.Add(MapObject(entity));
            }

            return dentityList;
        }       
        
    }
}
