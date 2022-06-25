using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SatuSeven.Contracts.Abstract.Providers.EntityFramework;

public abstract class EntityFrameworkProvider<TContext, TEntity, TId> : ICrudProvider<TEntity, TId>
    where TEntity : Entity
    where TContext : DbContext

{
    private readonly TContext _context;
    protected readonly DbSet<TEntity> dbSet;

    protected EntityFrameworkProvider(TContext context)
    {
        _context = context;

        // DbSet from context by model 
        this.dbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Return All rows in the table, ordering by Creation Date
    /// Does not track modifications
    /// </summary>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    public virtual async Task<List<TEntity>> GetAll(int take = Int32.MaxValue, int skip = 0)
    {
        return await dbSet.AsNoTracking().OrderBy(entity => entity.CreationDate).Skip(skip).Take(take).ToListAsync();
    }

    /// <summary>
    /// Tracks modifications
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task<TEntity?> GetById(TId id)
    {
        return await dbSet.FindAsync(id);
    }

    /// <summary>
    /// Gets data which are acceded by a query, ordering by Creation Date
    /// Does not track modifications
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    public virtual async Task<List<TEntity>> Get(Func<TEntity, bool> predicate,
        int take = int.MaxValue, int skip = 0)
    {
        return await dbSet.AsNoTrackingWithIdentityResolution()
            .OrderBy(entity => entity.CreationDate).Skip(skip).Take(take).ToListAsync();
    }

    /// <summary>
    /// Tracks modifications
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return await dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task Add(TEntity added)
    {
        await dbSet.AddAsync(added);
        await _context.SaveChangesAsync();
    }

    public virtual async Task AddRange(IEnumerable<TEntity> added)
    {
        await dbSet.AddRangeAsync(added);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Edit(TEntity edited)
    {
        _context.Entry(edited).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task Remove(TEntity removed)
    {
        dbSet.Remove(removed);
        await _context.SaveChangesAsync();
    }
}