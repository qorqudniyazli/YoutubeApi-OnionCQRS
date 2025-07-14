using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;
using YoutubeApi.Persistence.Repositories;
using YoutubeApi.Persistence.UnitOfWorks;

namespace YoutubeApi.Persistence;

public static class Registration
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddIdentityCore<User>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 2;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
}
