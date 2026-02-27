using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Core.Application.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        public IOrderRepository _repo;
        public OrderService(IOrderRepository repo) : base(repo)
        {
            _repo = repo;
        }
        public IQueryable<Order> GetAllQuery()
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
