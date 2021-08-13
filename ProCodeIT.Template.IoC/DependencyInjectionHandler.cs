using Microsoft.Extensions.DependencyInjection;
using ProCodeIT.Template.BLL.Infra.Services;
using ProCodeIT.Template.BLL.Services;
using ProCodeIT.Template.DAL;
using ProCodeIT.Template.DAL.Infra.Repositories;
using ProCodeIT.Template.DAL.Infra.UnitsOfWork;
using ProCodeIT.Template.DAL.Repositories;
using ProCodeIT.Template.DAL.UnitsOfWork;

namespace ProCodeIT.Template.IoC
{
    public static class DependencyInjectionHandler
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductUoW, ProductUow>();

            return services;
        }
    }
}
