using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TEQTechnicalAssessment.Application
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var domainAssembly = typeof(ApplicationInstallation).GetTypeInfo().Assembly;

            services.AddMediatR(domainAssembly);
            services.AddFluentValidation(new[] { domainAssembly });

            return services;
        }
    }
}