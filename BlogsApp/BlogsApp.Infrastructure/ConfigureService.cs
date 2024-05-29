using BlogsApp.Domain.Repository;
using BlogsApp.Infrastructure.Data;
using BlogsApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogsApp.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuraiton)
    {
        services.AddDbContext<BlogDbContext>(options =>
        {
            options.UseSqlite(configuraiton.GetConnectionString("BlogsDb") ??
                throw new InvalidOperationException("Connection string not found"));
        });

        services.AddTransient<IBlogRepository, BlogRepository>();

        return services;
    }
}
