namespace SatuSeven.Contracts.Abstract.Providers;

public interface ICudProvider<in TEntity, in TId> : ICreateOnlyProvider<TEntity, TId> where TEntity : class
{
    Task Edit(TEntity edited);
    Task Remove(TEntity removed);
}