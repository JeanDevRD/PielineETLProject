using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using ETLProject.Infrastructure.Persistence.Context;

namespace ETLProject.Infrastructure.Persistence.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(ETLDbContext context) : base(context)
        {
        }

        public IQueryable<OrderStatus> GetAllQuery()
        {
            return _context.Set<OrderStatus>().AsQueryable();
        }
    }
}
