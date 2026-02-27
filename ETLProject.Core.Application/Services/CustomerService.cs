using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;

namespace ETLProject.Core.Application.Services
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo) : base(repo) 
        { 
            _repo = repo;
        }

        public IQueryable<Customer> GetAllQuery()
        {
            try
            {
                return _repo.GetAllQuery();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al obtener entidades", ex);
            }
        }
    }
}
