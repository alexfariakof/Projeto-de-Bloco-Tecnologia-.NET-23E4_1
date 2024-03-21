using Microsoft.Extensions.DependencyInjection;
using PixCharge.Application.Account;
using PixCharge.Application.Account.Dto;
using PixCharge.Application.Transactions;
using PixCharge.Application.Transactions.Dto;
namespace PixCharge.Application.CommonInjectDependence;
public static class ServiceInjectDependence
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IService<CustomerDto>, CustomerService>();
        services.AddScoped<IService<ChargeDto>, ChargeService>();        
        return services;
    }
}

