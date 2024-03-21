using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;
using RealEstatePortal.Application.Abstractions.Persistence;
using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Infrastructure.Persistence.Mapping;
using RealEstatePortal.Infrastructure.Persistence.Migrations;
using RealEstatePortal.Infrastructure.Persistence.Plugins;
using RealEstatePortal.Infrastructure.Persistence.Repositories;

namespace RealEstatePortal.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddAutoMapper(typeof(Mapping.UserMapper));
        collection.AddAutoMapper(typeof(DealMapper));
        collection.AddAutoMapper(typeof(ReviewMapper));
        collection.AddAutoMapper(typeof(ObjectMapper));

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        // TODO: add repositories
        collection.AddScoped<IPersistenceContext, PersistenceContext>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IDealRepository, DealRepository>();
        collection.AddScoped<IObjectRepository, ObjectRepository>();
        collection.AddScoped<IReviewRepository, ReviewRepository>();

        return collection;
    }
}