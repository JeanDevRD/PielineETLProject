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
    public class OrderDetailService : GenericService<OrderDetail>, IOrderDetailService
    {
        IOrderDetailRepository _repo;
        public OrderDetailService(IOrderDetailRepository repo) : base(repo)
        {
           _repo = repo;
        }
    }
}
