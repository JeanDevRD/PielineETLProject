using ETLProject.Core.Domain.Entities;

namespace ETLProject.Core.Application.Interfaces
{
    public interface IOrderService : IGenericService<Order>
    {
        IQueryable<Order> GetAllQuery();
    }
}
