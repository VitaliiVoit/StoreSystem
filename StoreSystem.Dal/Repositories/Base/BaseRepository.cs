﻿namespace StoreSystem.Dal.Repositories.Base;

public abstract class BaseRepository<T> : IRepository<T>
    where T : BaseEntity
{
    public StoreSystemDbContext Context { get; }
    public DbSet<T> Table { get; }

    protected BaseRepository(StoreSystemDbContext context)
    {
        Context = context;
        Table = Context.Set<T>();
    }

    public virtual int Add(T entity)
    {
        Table.Add(entity);
        return SaveChanges();
    }

    public virtual int AddRange(IEnumerable<T> entites)
    {
        Table.AddRange(entites);
        return SaveChanges();
    }

    public virtual int Delete(T entity)
    {
        Table.Remove(entity);
        return SaveChanges();
    }

    public virtual int DeleteRange(IEnumerable<T> entites)
    {
        Table.RemoveRange(entites);
        return SaveChanges();
    }

    public virtual async Task<List<T>> GetAll()
    {
        return await Table.ToListAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await Table.FirstOrDefaultAsync(item => item.Id == id);
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }
}
