namespace StoreSystem.Dal.Repositories;

public class OrderRecordRepository : BaseRepository<OrderRecord>, IOrderRecordRepository
{
    public OrderRecordRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }
}
