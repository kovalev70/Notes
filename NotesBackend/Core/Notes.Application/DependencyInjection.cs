namespace Notes.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using FluentValidation;
    using MediatR;
    using Notes.Application.Behaviors;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
