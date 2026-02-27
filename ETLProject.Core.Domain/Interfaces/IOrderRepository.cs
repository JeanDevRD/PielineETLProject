using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;

namespace ETLProject.Core.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IQueryable<Order> GetAllQuery();
    }
}
