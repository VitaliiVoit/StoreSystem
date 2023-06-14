namespace StoreSystem.Dal.Repositories;

public class SellRepository : BaseRepository<Sell>, ISellRepository
{
    public SellRepository(StoreSystemDbContext context) : 
        base(context)
    {
    }

    public override async Task<List<Sell>> GetAll()
        => await Table.Include(s => s.OrderNavigation)
                .Include(s => s.SellerNavigation)
                .ToListAsync();
}
