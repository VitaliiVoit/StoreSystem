namespace StoreSystem.Dal.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }
}
