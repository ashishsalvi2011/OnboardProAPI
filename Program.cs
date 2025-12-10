
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using OnboardPro.Extensions;
using OnboardPro.Helper;
using OnboardPro.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
        .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
        .CreateLogger();

// Add services
builder.Services.AddControllers();
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddCustomCors();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Register custom operation filter
    options.OperationFilter<AddTenantHeaderParameter>();
});

builder.Services.AddAuthorization();
builder.Host.UseSerilog();
var app = builder.Build();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();
app.UseCors("MyCorse");
app.UseAuthentication();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<TenantMiddleware>(); 
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();
