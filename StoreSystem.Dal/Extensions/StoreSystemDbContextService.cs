using Microsoft.Extensions.DependencyInjection;
using StoreSystem.Dal.EfStructure;

namespace StoreSystem.Dal.Extensions;

public static class StoreSystemDbContextService
{
    public static IServiceCollection AddStoreSystemDbContext(
        this IServiceCollection services, 
        string connectionString)
    {
        services.AddDbContext<StoreSystemDbContext>(options 
            => options.UseSqlServer(connectionString));
        return services;
    }
}
