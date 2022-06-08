using TEQTechnicalAssessment.Domain.Enums;
using TEQTechnicalAssessment.Domain.SharedKernel;

namespace TEQTechnicalAssessment.Domain.Entities
{
    public class Email : Entity<Guid>
    {
        public Email(int templateId, string template, string title, string to, EmailStatus status)
            : base(Guid.NewGuid())
        {
            // TODO: Add guarding

            TemplateId = templateId;
            Template = template;
            Title = title;
            To = to;
            Status = status;
        }

        public int TemplateId { get; init; }
        public string Template { get; init; }
        public string Title { get; init; }
        public string To { get; init; }
        public EmailStatus Status { get; private set; }

        public void UpdateStatus(EmailStatus status) => Status = status;

        public string Message() => "To be created with data provided by the external services";
    }
}