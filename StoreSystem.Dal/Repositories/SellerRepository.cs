namespace StoreSystem.Dal.Repositories;

public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }

    public override async Task<Seller?> GetById(int id)
        => await Table.FirstOrDefaultAsync(s => s.Id == id);
}
