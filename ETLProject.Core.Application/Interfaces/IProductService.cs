
using ETLProject.Core.Domain.Entities;


namespace ETLProject.Core.Application.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        IQueryable<Product> GetAllQuery();
    }
}
