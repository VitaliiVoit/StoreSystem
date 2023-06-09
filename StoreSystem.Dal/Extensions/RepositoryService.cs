using Microsoft.Extensions.DependencyInjection;
using StoreSystem.Dal.Repositories;

namespace StoreSystem.Dal.Extensions;

public static class RepositoryService
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<ISellerRepository, SellerRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderRecordRepository, OrderRecordRepository>()
                .AddScoped<ISellRepository, SellRepository>();

        return services;
    }
}
