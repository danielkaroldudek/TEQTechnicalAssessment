using MediatR;

namespace TEQTechnicalAssessment.Application
{
    // TODO: Define the payload for the email data
    public record SendEmailCommand(int TemplateId, string To, string Title) : IRequest<Guid>;
}
