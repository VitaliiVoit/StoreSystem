namespace StoreSystem.Dal.Repositories;

public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }

    public async Task<Seller?> GetByFullName(string fullName)
        => await Table.Where(s => s.FullName == fullName)
                .FirstOrDefaultAsync();

    public async Task<Seller?> GetByFullNameAndPhone(string fullname, string phone)
        => await Table.Where(s => s.FullName == fullname && s.Phone == phone)
                .FirstOrDefaultAsync();

    public async Task<Seller?> GetByPhoneAndPassword(string phone, string password)
        => await Table.Where(s => s.Phone == phone && s.Password == password)
                .FirstOrDefaultAsync();

    public override async Task<Seller?> GetById(int id)
        => await Table.FirstOrDefaultAsync(s => s.Id == id);
}
