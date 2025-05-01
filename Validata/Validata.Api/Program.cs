using Asp.Versioning;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Validata.Api.Middleware;
using Validata.Application.Commands.CreateCustomer;
using Validata.Application.Interfaces;
using Validata.Application.Mapping;
using Validata.Infrastructure;
using Validata.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateCustomerCommand).Assembly
    );
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("x-api-version")
    );
}).AddMvc();

builder.Services.AddDbContext<ValidataDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);

builder.Services.AddFluentValidationAutoValidation()
      .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteCustomerCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCustomerCommandValidator>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add services to the container.
builder.Services.AddControllers().AddXmlSerializerFormatters();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
