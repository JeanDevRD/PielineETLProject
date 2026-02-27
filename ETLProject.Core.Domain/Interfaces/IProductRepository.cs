using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;

namespace ETLProject.Core.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetAllQuery();
    }
}
