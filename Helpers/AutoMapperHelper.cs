using AutoMapper;
using TIP.Extensions;

namespace TIP.Helpers
{
    public static class AutoMapperHelper<TSource, TDestination>
    {
        private static Mapper _myAutoMapper = new Mapper(new MapperConfiguration(
            cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMap<TSource, TDestination>()
                        .IgnoreNoMap();
            }
            ));

        public static TDestination Map(TSource source)
        {
            return _myAutoMapper.Map<TDestination>(source);
        }

        public static List<TDestination> MapList(List<TSource> source)
        {
            var list = new List<TDestination>();

            source.ForEach(x => { list.Add(Map(x)); });

            return list;
        }
    }
}
