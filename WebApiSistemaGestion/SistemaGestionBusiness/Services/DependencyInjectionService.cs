using SistemaGestionData.dataBase;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData.ContextFactory;
using SistemaGestionData.Interfaces;
using SistemaGestionData.Repositories;
using Microsoft.EntityFrameworkCore;
using SistemaGestionMapper;

namespace SistemaGestionBusiness.Services
{
    public static class DependencyInjectionService
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registra aquí todos tus servicios

            //context
            services.AddScoped <CoderContext>();
            //context factory
            services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();
            //mappers
            services.AddScoped<UserMapper>();
            services.AddScoped<ProductMapper>();
            services.AddScoped<SaleMapper>();
            services.AddScoped<ProductSoldMapper>();
            //repositories and services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<IProductoRepository, ProductRepository>();
            services.AddScoped<ProductService>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<SaleService>();
            services.AddScoped<IProductsSoldRepository, ProductsSoldRepository>();
            services.AddScoped<ProductsSoldService>();

            // Agrega más servicios según sea necesario
        }
    }
}
