namespace StoreSystem.Dal.Repositories.Base;

public interface IRepository<T>
{
    int Add(T entity);
    int AddRange(IEnumerable<T> entites);
    int Update(T entity);
    int UpdateRange(IEnumerable<T> entites);
    int Delete(T entity);
    int DeleteRange(IEnumerable<T> entites);
    T? GetById(int id);
    Task<List<T>> GetAll();
    int SaveChanges();
}
