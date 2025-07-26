using Microsoft.EntityFrameworkCore;
using Serilog;
using template_webapi.Common.Interfaces;
using template_webapi.Common.Middelwares;
using template_webapi.Common.Repositories;
using template_webapi.Common.Services;
using template_webapi.Data;
using template_webapi.Data.Entities;
using template_webapi.Features.Customers.Interfaces;
using template_webapi.Features.Customers.Repository;
using template_webapi.Features.Customers.Service;
using template_webapi.Features.Employees.Dtos;
using template_webapi.Features.Orders.Repository;
using template_webapi.Features.Orders.Service;
using template_webapi.Features.Products.Dtos;
using template_webapi.Features.Shippers.Dtos;


var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

// Services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddValidatorsFromAssemblyContaining<ClientCreateValidator>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGenericService<Employee, EmployeeResponse>, GenericService<Employee, EmployeeResponse>>();
builder.Services.AddScoped<IGenericService<Shipper, ShipperResponse>, GenericService<Shipper, ShipperResponse>>();
builder.Services.AddScoped<IGenericService<Product, ProductResponse>, GenericService<Product, ProductResponse>>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
// CORS
var frontUrl = builder.Configuration.GetValue<string>("allowedUrl");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontUrl!).AllowAnyMethod().AllowAnyHeader();
    });
});

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
