using System.Linq.Expressions;

namespace SatuSeven.Contracts.Abstract.Providers;

public interface IReadProvider<TEntity, in TId> where TEntity : class
{
    Task<List<TEntity>> GetAll(int take = int.MaxValue, int skip = 0);
    Task<TEntity?> GetById(TId id);
    Task<List<TEntity>> Get(Func<TEntity, bool> predicate, int take = int.MaxValue, int skip = 0);
    Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
}