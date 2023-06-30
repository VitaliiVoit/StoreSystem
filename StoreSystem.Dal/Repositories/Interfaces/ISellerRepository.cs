namespace StoreSystem.Dal.Repositories.Interfaces;

public interface ISellerRepository : IRepository<Seller>
{
    Task<Seller?> GetByFullName(string fullName);
    Task<Seller?> GetByPhone(string phone);
    Task<Seller?> GetByPhoneAndPassword(string phone, string password);
}
