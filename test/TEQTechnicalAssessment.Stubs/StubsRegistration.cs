using Microsoft.Extensions.DependencyInjection;
using TEQTechnicalAssessment.Domain.Repositories;
using TEQTechnicalAssessment.Infrastructure.MessageBus;

namespace TEQTechnicalAssessment.Stubs
{
    public static class StubsRegistration
    {
        public static IServiceCollection AddStubs(this IServiceCollection services)
        {
            services.AddTransient<IMessageBus, MessageBusStub>();
            services.AddTransient<IEmailRepository, EmailRepositoryStub>();
            services.AddTransient<IEmailTemplateRepository, EmailTemplateRepositoryStub>();

            return services;
        }
    }
}