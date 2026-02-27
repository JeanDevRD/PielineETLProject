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
    public class OrderStatusService : GenericService<OrderStatus>,IOrderStatusService
    {
        IOrderStatusRepository _repo;
        public OrderStatusService(IOrderStatusRepository repo) : base(repo) 
        { 
           _repo = repo;
        }

        public IQueryable<OrderStatus> GetAllQuery()
        {
            var status = _repo.GetAllQuery();

            try
            {
                if (status != null)
                {
                    return status;
                }
                Console.WriteLine($"no se encontraron status en la base de datos");
                return null!;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al obtener entidades", ex);
            }
            

            
        }
    }
}
