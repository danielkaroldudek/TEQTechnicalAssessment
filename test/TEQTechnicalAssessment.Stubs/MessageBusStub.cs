using TEQTechnicalAssessment.Domain.Commands;
using TEQTechnicalAssessment.Infrastructure.MessageBus;

namespace TEQTechnicalAssessment.Stubs
{
    public class MessageBusStub : IMessageBus
    {
        public Task Publish(SendEmailWithTemplateCommand sendEmailWithTemplateCommand) => Task.CompletedTask;
    }
}
