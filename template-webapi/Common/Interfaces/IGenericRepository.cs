namespace template_webapi.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}
