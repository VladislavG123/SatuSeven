namespace SatuSeven.Contracts.Abstract.Providers;

public interface ICreateOnlyProvider<in TEntity, in TId> where TEntity : class
{
    Task Add(TEntity added);
    Task AddRange(IEnumerable<TEntity> added);
}