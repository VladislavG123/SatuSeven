namespace SatuSeven.Contracts.Abstract.Providers;

public interface ICrudProvider<TEntity, in TId>
    : IReadProvider<TEntity, TId>, ICudProvider<TEntity, TId>
    where TEntity : class
{
}