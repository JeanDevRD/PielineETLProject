using ETLProject.Core.Application.CSVs;
using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Domain.Entities;
using ETLProject.Core.Domain.Interfaces;
using ETLProyect.Infrastructure.Shared;
using System.Threading.Tasks;

namespace ETLProject.Core.Application.Services
{
    public class LoadService : ILoadService
    {
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ICustomerService _customerService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IOrderStatusService _orderStatusService;
        private readonly IProductService _productService;

        public LoadService(ICategoryService category, ICityService city, ICountryService country,
            ICustomerService customer, IOrderDetailService orderDetail, IOrderService order,
            IOrderStatusService orderStatus, IProductService product)
        {
            _categoryService = category;
            _cityService = city;
            _countryService = country;
            _customerService = customer;
            _orderDetailService = orderDetail;
            _orderService = order;
            _orderStatusService = orderStatus;
            _productService = product;
        }

        public async Task LoadCustomers(List<CustomerCsv> customers)
        {
            try
            {
                var countries = customers.Select(c => c.Country!).Distinct()
                    .Select(name => new Country 
                    { 
                        Id = 0, 
                        CountryName = name

                    }).ToList();

                var addedCountries = await _countryService.LoadAsync(countries);

                var countryDict = _countryService.GetAllQuery().ToDictionary(c => c.CountryName, c => c.Id);

                Console.WriteLine($"Paises agregados a la base de datos: {addedCountries.Count()}");

                var cities = customers.DistinctBy(c => new { c.City, c.Country })
                     .Select(c => new City
                     {
                         Id = 0,
                         CityName = c.City!,
                         CountryID = countryDict[c.Country!]

                     }).ToList();

                var addedCities = await _cityService.LoadAsync(cities);

                var cityDict = _cityService.GetAllQuery().ToDictionary(c => $"{c.CityName}-{c.Country!.CountryName}", c => c.Id);

                Console.WriteLine($"ciudades agregadas a la base de datos: {addedCities.Count()}");

                var customersAdd = customers.DistinctBy(c => c.Email).Select(c => new Customer
                {
                    Id = c.CustomerID,
                    FirstName = c.FirstName!,
                    LastName = c.LastName!,
                    Email = c.Email!,
                    Phone = PhoneHelper.FormatPhone(c.Phone),
                    CityID = cityDict[$"{c.City}-{c.Country}"]

                });

                var addedCustomers = await _customerService.LoadAsync(customersAdd);

                Console.WriteLine($"Customers agregados a la base de datos: {addedCustomers.Count()}");
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al leer el CSV", ex);
            }
        
        }
        public async Task LoadOrders(List<OrderCsv> orders) 
        {
            try
            {
                var orderStatus = orders.Select(o => o.Status).Distinct().ToList();

                var Addstatues = orderStatus.Select(o => new OrderStatus
                {
                   Id = 0,
                   StatusName = o!

                }).ToList();

                var statusAdded = await _orderStatusService.LoadAsync(Addstatues);

                Console.WriteLine($"Status agregados a la base dedatos: {statusAdded.Count()}");

                var statusDict = _orderStatusService.GetAllQuery().ToDictionary(s => s.StatusName, s => s.Id);

                var customerIds = _customerService.GetAllQuery().Select(c => c.Id).ToHashSet();

                var ordersAdd= orders
                    .Where(o => customerIds.Contains(o.CustomerID))
                    .Select(o => new Order
                    {
                        Id = o.OrderID,
                        CustomerID = o.CustomerID,
                        OrderDate = o.OrderDate!,
                        StatusID = statusDict[o.Status!]
                    })
                    .ToList();

                var ordersAdded = await _orderService.LoadAsync(ordersAdd);

                Console.WriteLine($"Ordenes añadidas a la base de datos: {ordersAdded.Count()}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer el CSV", ex);
            }

        }
        public async Task LoadProducts(List<ProductCsv> products) 
        {
            try
            {
                var categories = products.Select(p => p.Category!).Distinct()
                 .Select(name => new Category
                 {
                     Id = 0,
                     CategoryName = name
                 }).ToList();

                var addedCategories = await _categoryService.LoadAsync(categories);

                var categoryDict = _categoryService.GetAllQuery().ToDictionary(c => c.CategoryName, c => c.Id);

                Console.WriteLine($"Categorías agregadas a la base de datos: {addedCategories.Count()}");

                var productsAdd = products.Select(p => new Product
                {
                    Id = p.ProductID,
                    ProductName = p.ProductName!,
                    CategoryID = categoryDict[p.Category!],
                    Price = p.Price!.Value,
                    Stock = p.Stock,
                }).ToList();

                var addedProducts = await _productService.LoadAsync(productsAdd);

                Console.WriteLine($"Productos agregados a la base de datos: {addedProducts.Count()}");
                

            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer el CSV", ex);
            }

        }
        public async Task LoadOrderDetail(List<OrderDetailCsv> orderDetail) 
        {
            try
            {
                var orderIds = _orderService.GetAllQuery().Select(o => o.Id).ToHashSet();

                var productIds = _productService.GetAllQuery().Select(p => p.Id).ToHashSet();
                
                var orderDetailsAdd = orderDetail.Where(od => orderIds.Contains(od.OrderID) 
                && productIds.Contains(od.ProductID)).Select(od => new OrderDetail
                    {
                        Id = 0, 
                        OrderID = od.OrderID,
                        ProductID = od.ProductID,
                        Quantity = od.Quantity,
                        TotalPrice = od.TotalPrice
                    }).ToList();

                var addedOrderDetails = await _orderDetailService.LoadAsync(orderDetailsAdd);

                Console.WriteLine($"Productos agregados a la base de datos: {addedOrderDetails.Count()}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer el CSV", ex);
            }

        }
    }
}
