using AutoMapper;
using template_webapi.Common.Interfaces;

namespace template_webapi.Common.Services
{
    public class GenericService<TEntity, TResponse> : IGenericService<TEntity, TResponse>
        where TEntity : class
        where TResponse : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TResponse>>(entities);
        }

    }
}
