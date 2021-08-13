using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProCodeIT.Template.IoC.Mappings;

namespace ProCodeIT.Template.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            // TODO: Adicionar Conexão com Banco de Dados

            //services.AddDbContext<MyDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("ProCodeIT.Template.API"))
            //);

            return services;
        }

        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProduct());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            mappingConfig.AssertConfigurationIsValid();

            services.AddSingleton(mapper);

            return services;
        }
    }

}
