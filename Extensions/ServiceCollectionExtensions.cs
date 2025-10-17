using OnboardPro.Helper;
using OnboardPro.Interface;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Repositories;
using OnboardPro.Repository;
using OnboardPro.Services;

namespace OnboardPro.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoginOTPService, LoginOTPService>();
            services.AddScoped<ILoginOTPRepository, LoginOTPRepository>();
            services.AddScoped<IMenuService,MenuService>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<JwtService>();
            services.AddSingleton<IResponse, ResponseService>();
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddHttpContextAccessor();
            services.AddScoped<ITenantProvider, TenantProviderService>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Program));
            services.AddHttpContextAccessor();

            return services;

        }
    }
}
    