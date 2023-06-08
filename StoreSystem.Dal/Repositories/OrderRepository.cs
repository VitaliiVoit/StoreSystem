namespace StoreSystem.Dal.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }
}
