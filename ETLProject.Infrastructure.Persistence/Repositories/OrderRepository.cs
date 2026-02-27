using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using ETLProject.Infrastructure.Persistence.Context;

namespace ETLProject.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ETLDbContext context) : base(context)
        {
        }
        public IQueryable<Order> GetAllQuery()
        {
            return _context.Set<Order>().AsQueryable();
        }

    }
}
