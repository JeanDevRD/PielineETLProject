
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using ETLProject.Infrastructure.Persistence.Context;

namespace ETLProject.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(ETLDbContext context) : base(context)
        {

        }

        public IQueryable<Product> GetAllQuery()
        {
            return _context.Set<Product>().AsQueryable();
        }
    }
}
