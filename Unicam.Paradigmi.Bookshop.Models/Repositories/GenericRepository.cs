using Microsoft.EntityFrameworkCore;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class GenericRepository<T> where T : class
{
    protected readonly DbContext Context;
    
    public GenericRepository(DbContext context)
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