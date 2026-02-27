using ETLProject.Core.Application.Interfaces;

namespace ETLProject.Core.Application.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> 
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> LoadAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                return await _repository.LoadAsync(entity);
            }
            catch (Exception ex) 
            {

                throw new Exception($"Error loading entities: {ex.Message}", ex);
            }
        }

    }
}
