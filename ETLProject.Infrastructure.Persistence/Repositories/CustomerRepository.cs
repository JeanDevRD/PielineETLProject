using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using ETLProject.Infrastructure.Persistence.Context;
namespace ETLProject.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ETLDbContext context) : base(context)
        {

        }

        public IQueryable<Customer> GetAllQuery()
        {
            return _context.Set<Customer>().AsQueryable();
        }
    }
}
