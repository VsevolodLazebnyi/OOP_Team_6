using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstatePortal.Infrastructure.Persistence.Contexts;

namespace RealEstatePortal.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        // TODO: add services
        return collection;
    }

    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}