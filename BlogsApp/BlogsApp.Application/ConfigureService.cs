using BlogsApp.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogsApp.Application;

public static class ConfigureService
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register AutoMapper and scan the current assembly for profiles.
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Fluent Validations
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register MediatR and scan the current assembly for handlers.
        services.AddMediatR(x =>
        {
            // Register all services (handlers, notifications, etc.) from the current assembly.
            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            // Validation
            x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        return services;
    }
}
