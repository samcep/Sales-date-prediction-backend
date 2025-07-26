using Microsoft.EntityFrameworkCore;
using template_webapi.Common.Interfaces;
using template_webapi.Data;

namespace template_webapi.Common.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<GenericRepository<TEntity>> _logger;
        public GenericRepository(ApplicationDbContext applicationDbContext, ILogger<GenericRepository<TEntity>> logger)
        {
            _dbContext = applicationDbContext;
            _logger = logger;
        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all entities of type {EntityType}", typeof(TEntity).Name);
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }


    }
}
