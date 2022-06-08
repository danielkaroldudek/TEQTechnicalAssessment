using TEQTechnicalAssessment.Domain.Commands;

namespace TEQTechnicalAssessment.Infrastructure.MessageBus
{
    public interface IMessageBus
    {
        Task Publish(SendEmailWithTemplateCommand sendEmailWithTemplateCommand);
    }
}