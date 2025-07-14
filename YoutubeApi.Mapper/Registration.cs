using Microsoft.Extensions.DependencyInjection;

namespace YoutubeApi.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<YoutubeApi.Application.Interfaces.AutoMapperInterface.IMapper, AutoMapper.Mapper>();
    }
}
