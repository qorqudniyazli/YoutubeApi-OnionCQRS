﻿using AutoMapper;
using AutoMapper.Internal;

namespace YoutubeApi.Mapper.AutoMapper;

public class Mapper : Application.Interfaces.AutoMapperInterface.IMapper
{
    public static List<TypePair> typePairs = new();
    private IMapper MapperContainer;

    public Mapper()
    {

    }
    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<TSource, TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        Config<TDestination, object>(5, ignore);
        return MapperContainer.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        Config<TDestination, IList<object>>(5, ignore);
        return MapperContainer.Map<IList<TDestination>>(source);
    }
    protected void Config<TDestination, TSource>(int depth, string ignore = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestination));
        if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
        {
            return;
        }
        typePairs.Add(typePair);
        var config = new MapperConfiguration(cfg =>
        {
            foreach (var item in typePairs)
            {
                if (ignore is not null)
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                else
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
            }
        });
        MapperContainer = config.CreateMapper();
    }
}
