using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using TEQTechnicalAssessment.Stubs;

namespace TEQTechnicalAssessment.Application.AcceptanceTests
{
    public class BaseAcceptanceTest
    {
        protected readonly IServiceProvider serviceProvider;
        protected readonly IMediator mediator;

        public BaseAcceptanceTest()
        {
            serviceProvider = BuildServiceProvider();
            mediator = serviceProvider.GetService<IMediator>();
        }

        private IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddApplication();
            services.AddStubs();

            return services.BuildServiceProvider();
        }
    }
}
