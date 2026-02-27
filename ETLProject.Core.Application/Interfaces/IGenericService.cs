

namespace ETLProject.Core.Application.Interfaces
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        public Task<IEnumerable<TEntity>> LoadAsync(IEnumerable<TEntity> entity);
    }
}
