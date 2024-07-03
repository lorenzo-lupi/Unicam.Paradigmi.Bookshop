using Unicam.Paradigmi.Bookshop.Models.Context;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class GenericRepository<T> where T : class
{
    protected readonly MyDbContext Context;

    protected GenericRepository(MyDbContext context)
    {
        Context = context;
    }

    public GenericRepository<T> Add(T entity)
    {
        Context.Set<T>().Add(entity);
        return this;
    }

    public GenericRepository<T> Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
        return this;
    }

    public GenericRepository<T> RemoveDetached(T entity)
    {
        Context.Attach(entity);
        return Remove(entity);
    }

    public GenericRepository<T> Update(T entity)
    {
        Context.Set<T>().Update(entity);
        return this;
    }

    public async Task<int> SaveAsync()
    {
        return await Context.SaveChangesAsync();
    }
}