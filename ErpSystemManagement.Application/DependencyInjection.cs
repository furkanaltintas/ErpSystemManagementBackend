using ErpSystemManagement.Domain.Entities.ValueObjects;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ErpSystemManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assembly);
        });

        services.AddValidatorsFromAssembly(assembly);


        services.AddScoped<OrderNumberGenerator>();


        return services;
    }
}
