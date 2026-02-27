using ETLProject.Core.Application.CSVs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProject.Core.Application.Interfaces
{
    public interface ILoadService
    {
      public Task LoadCustomers(List<CustomerCsv> customers);
      public Task LoadOrders(List<OrderCsv> orders);
      public Task LoadProducts(List<ProductCsv> products);
      public Task LoadOrderDetail(List<OrderDetailCsv> orderDetail);
    }
}
