namespace template_webapi.Common.Interfaces
{
    public interface IGenericService<TEntity, TResponse>
        where TEntity : class
        where TResponse : class
    {
        Task<IEnumerable<TResponse>> GetAllAsync(CancellationToken cancellationToken);
    }
}
