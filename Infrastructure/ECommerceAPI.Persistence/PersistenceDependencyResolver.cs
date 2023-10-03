using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Context;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerceAPI.Persistence
{
  public static class PersistenceDependencyResolver
  {
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ECommerceDbContext>(option =>
      {
        option.UseNpgsql(configuration.GetConnectionString("ECommerceDB"));
      });

      services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
      services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

      services.AddScoped<IOrderReadRepository, OrderReadRepository>();
      services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

      services.AddScoped<IProductReadRepository, ProductReadRepository>();
      services.AddScoped<IProductWriteRespository, ProductWriteRepository>();

    }

  }
}
