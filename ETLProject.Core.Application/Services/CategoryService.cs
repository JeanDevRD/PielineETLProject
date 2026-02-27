using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;

namespace ETLProject.Core.Application.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public IQueryable<Category> GetAllQuery() 
        {
            try
            {
                var categories = _repo.GetAllQuery();

                if (categories != null) 
                {
                    return categories;
                }

                Console.WriteLine($"no se encontró categorias en la base de datos");
                return null!;
                    
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener enridades", ex);
            }
        
        }

    }
}
