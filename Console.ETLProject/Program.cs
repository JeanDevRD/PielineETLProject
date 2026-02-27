using CsvHelper;
using ETLProject.Core.Application;
using ETLProject.Core.Application.CSVs;
using ETLProject.Core.Application.Interfaces;
using ETLProject.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var services = new ServiceCollection();

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json") .Build();

services.AddApplicationLayer();
services.AddPersistenceLayer(config); 

var provider = services.BuildServiceProvider();

List<CustomerCsv> customersCsv;
List<ProductCsv> productsCsv;
List<OrderCsv> ordersCsv;
List<OrderDetailCsv> orderDetailsCsv;

var customerFilePath = config["CsvPaths:Customers"];
var productFilePath = config["CsvPaths:Products"];
var orderFilePath = config["CsvPaths:Orders"];
var orderDetailFilePath = config["CsvPaths:OrderDetails"];

using (var reader = new StreamReader(customerFilePath!))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))

    customersCsv = csv.GetRecords<CustomerCsv>().Where(c => c.CustomerID != 0
                     && !string.IsNullOrWhiteSpace(c.FirstName)
                     && !string.IsNullOrWhiteSpace(c.LastName)
                     && !string.IsNullOrWhiteSpace(c.Email)).ToList();

    
                 

using (var reader = new StreamReader(productFilePath!))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    
productsCsv = csv.GetRecords<ProductCsv>().Where(p => p.ProductID != 0 
                 && !string.IsNullOrWhiteSpace(p.ProductName)
                 && !string.IsNullOrWhiteSpace(p.Category) && p.Price.HasValue && p.Price > 0
                 && p.Stock >= 0).ToList();

using (var reader = new StreamReader(orderFilePath!))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))

    ordersCsv = csv.GetRecords<OrderCsv>().Where(o => o.OrderID != 0
                     && o.CustomerID != 0 && o.OrderDate != null
                     && !string.IsNullOrWhiteSpace(o.Status)).ToList();

using (var reader = new StreamReader(orderDetailFilePath!))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))

orderDetailsCsv = csv.GetRecords<OrderDetailCsv>().Where(od => od.OrderID > 0 && od.ProductID > 0
                  && od.Quantity > 0 && od.TotalPrice >= 0)
                  .DistinctBy(od => new { od.OrderID, od.ProductID }).ToList();


var loadService = provider.GetRequiredService<ILoadService>();

await loadService.LoadCustomers(customersCsv);
await loadService.LoadProducts(productsCsv);
await loadService.LoadOrders(ordersCsv);
await loadService.LoadOrderDetail(orderDetailsCsv);

Console.WriteLine("ETL completado.");