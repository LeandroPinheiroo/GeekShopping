using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Services;

namespace GeekShopping.ProductAPI.Startup
{
    public static class DependencyInjecttionSetup
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton(MappingConfig.RegisterMaps().CreateMapper());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddEndpointsApiExplorer();

            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Geek Shopping", Version = "v1" });
            });
            //Register all Repositories Injection
            services.RegisterRepository();
            //Register all Services Injection
            services.RegisterServices();
            return services;
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<ProductRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
        }
    }
}
