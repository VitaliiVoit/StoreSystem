namespace StoreSystem.Dal.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }

    public override async Task<List<Customer>> GetAll()
        => await Table.Include(c => c.Orders)
                .OrderBy(c => c.FullName)
                .ToListAsync();

    public override async Task<Customer?> GetById(int id)
        => await Table.Where(c => c.Id == id)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync();

}
