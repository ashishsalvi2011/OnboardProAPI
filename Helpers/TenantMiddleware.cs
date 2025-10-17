using OnboardPro.Models;
using OnboardPro.Services;
using System.IO;

namespace OnboardPro.Helper
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider, IConfiguration config)
        {

            var path = context.Request.Path;

            // Allow static images without tenant check
           if (path.StartsWithSegments("/Images"))
            {
                await _next(context);
                return;
            }


            var tenantId = context.Request.Headers["X-Tenant-ID"].FirstOrDefault();

            if (string.IsNullOrEmpty(tenantId))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Missing X-Tenant-ID header");
                return;
            }

            // Load connection string from config or DB
            var connStr = config.GetConnectionString(tenantId);
            if (string.IsNullOrEmpty(connStr))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid tenant or no connection string found");
                return;
            }

            var tenant = new TenantInfoModel
            {
                TenantId = tenantId,
                ConnectionString = connStr
            };

            tenantProvider.SetTenant(tenant);
            await _next(context);
        }
    }
}
