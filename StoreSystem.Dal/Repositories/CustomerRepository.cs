namespace StoreSystem.Dal.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(StoreSystemDbContext context) 
        : base(context)
    {
    }

    public override IEnumerable<Customer> GetAll()
        => Table.Include(c => c.Orders)
                .OrderBy(c => c.FullName);

    public override Customer? GetById(int id)
        => Table.Where(c => c.Id == id)
                .Include(c => c.Orders)
                .FirstOrDefault();

}
