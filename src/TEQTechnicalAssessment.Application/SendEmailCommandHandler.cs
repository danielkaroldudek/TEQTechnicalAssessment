using MediatR;
using TEQTechnicalAssessment.Domain.Commands;
using TEQTechnicalAssessment.Domain.Entities;
using TEQTechnicalAssessment.Domain.Repositories;
using TEQTechnicalAssessment.Infrastructure.MessageBus;

namespace TEQTechnicalAssessment.Application
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Guid>
    {
        private readonly IEmailTemplateRepository emailTemplateRepository;
        private readonly IEmailRepository emailRepository;
        private readonly IMessageBus messageBus;

        public SendEmailCommandHandler(IEmailTemplateRepository emailTemplateRepository, IEmailRepository emailRepository, IMessageBus messageBus)
        {
            this.emailRepository = emailRepository;
            this.emailTemplateRepository = emailTemplateRepository;
            this.messageBus = messageBus;
        }

        public async Task<Guid> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var emailTemplate = await emailTemplateRepository.Get(request.TemplateId);

            if (string.IsNullOrEmpty(emailTemplate))
            {
                // TODO: Introduce errors
                return Guid.Empty;
            }

            Email email = new(request.TemplateId, emailTemplate, request.Title, request.To, Domain.Enums.EmailStatus.ToBeSent);

            await emailRepository.Create(email);

            await messageBus.Publish(new SendEmailWithTemplateCommand(email.Title, email.To, email.Message()));

            return email.Id;
        }
    }
}
