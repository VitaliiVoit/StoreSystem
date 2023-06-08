namespace StoreSystem.Dal.Repositories;

public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }

    public override Seller? GetById(int id)
        => Table.FirstOrDefault(s => s.Id == id);
}
