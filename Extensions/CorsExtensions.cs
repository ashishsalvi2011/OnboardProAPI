namespace OnboardPro.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(Options => Options.AddPolicy("MyCorse", policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            return services;
        }
    }
}
