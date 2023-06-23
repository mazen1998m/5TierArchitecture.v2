using app.core;
using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.Application.Addresses.Validator;
using App.core.InjectionHelper;
using App.web.Services.AllAssemblyServices;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace App.web.Services.InjectionService;

public static class DependencyInjectionService
{
    //todo:create AutoAddSingleton
    //todo:insure this class run one time
    public static IServiceCollection AutoInjectedServices(this IServiceCollection services)
    {
        List<InjectionAttribute> sortedAttributes = new();

        IEnumerable<Type> types = AssemblyServices.GetTypes()
            .Where(
                     t => t.IsPublic
                     && t.IsClass && !t.IsSubclassOf(typeof(ShowDto))
                     && !t.IsSubclassOf(typeof(Entity))
            );
        foreach (Type? type in types)
        {
            object[] attributes = type.GetCustomAttributes(typeof(InjectionAttribute), false);
            if (attributes.Length != 0)
                sortedAttributes.AddRange(attributes.Cast<InjectionAttribute>());

        }

        sortedAttributes = sortedAttributes.OrderBy(x => x.Order).Distinct().ToList();

        foreach (InjectionAttribute attribute in sortedAttributes)
        {
            services.AddScoped(attribute.Interface, attribute.Implementation);
        }

        return services;
    }


    /// <summary>
    /// Adds services to the service collection for auto-scoping and auto-mapping.
    ///This code adds scoped services and AutoMapper types to an IServiceCollection.
    ///It first gets all interface and class types from the Services class that implement IAutoInjection.
    ///It then adds each implementation type to the service collection as a scoped service.
    ///Finally, it adds each type that inherits from the Profile class to the service collection for AutoMapper
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddAutoScoped(this IServiceCollection services)
    {
        // Get all types from the Services class that are interfaces and implement IAutoInjection
        IEnumerable<Type> interfaceTypes = AssemblyServices.GetTypes()
            .Where(a => a.IsInterface && a.GetInterfaces().Any(i => i == typeof(IAutoInjection)));

        // Get all types from the Services class that are classes and implement IAutoInjection
        List<Type> implementationTypes = AssemblyServices.GetTypes()
            .Where(a => a.IsClass && a.GetInterfaces().Any(i => i == typeof(IAutoInjection))).ToList();

        // Get all types from the Services class that inherit from the Profile class
        IEnumerable<Type> autoMapperTypes = AssemblyServices.GetTypes()
            .Where(a => a.BaseType == typeof(Profile));

        // For each interface type that implements IAutoInjection
        foreach (Type? interfaceType in interfaceTypes)
        {
            // Get the implementation types that implement the interface
            IEnumerable<Type> types = implementationTypes
                .Where(a => a.GetInterfaces()
                    .Any(
                            i => i.Name == interfaceType.Name
                             && a.Namespace == interfaceType.Namespace
                        )
                );

            // Add the implementation type to the service collection as a scoped service
            foreach (Type? type in types)
            {
                services.AddScoped(interfaceType, type);
            }
        }

        // For each type that inherits from the Profile class
        foreach (var type in autoMapperTypes) services.AddAutoMapper(type);

        services.AddValidatorsFromAssemblyContaining<AddressesDtoValidator>();

        // Return the service collection
        return services;
    }

    public static IServiceCollection AddEfDbContext<TYpeContext>(this IServiceCollection services, WebApplicationBuilder builder)
    where TYpeContext : DbContext
    {
        services.AddDbContext<TYpeContext>(
            options => options.UseSqlServer(builder.Configuration
                    .GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(TYpeContext).Assembly.FullName))
        );
        return services;

        //.UseLazyLoadingProxies()
    }

}

