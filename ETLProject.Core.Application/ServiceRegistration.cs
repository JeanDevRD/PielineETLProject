using ETLProject.Core.Application.Interfaces;
using ETLProject.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
namespace ETLProject.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryServices>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<ILoadService, LoadService>();
        }
    }
}
