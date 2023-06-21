namespace StoreSystem.Dal.Repositories.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByFullName(string fullName);
}
