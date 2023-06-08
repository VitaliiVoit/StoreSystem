using Microsoft.Extensions.DependencyInjection;

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
