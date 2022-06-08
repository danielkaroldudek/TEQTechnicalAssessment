using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using TEQTechnicalAssessment.Domain.Commands;
using TEQTechnicalAssessment.Domain.Entities;
using TEQTechnicalAssessment.Domain.Repositories;
using TEQTechnicalAssessment.Infrastructure.MessageBus;
using Xunit;

namespace TEQTechnicalAssessment.Application.UnitTests
{
    public class SendEmailCommandTests
    {
        [Fact]
        public async Task SendEmailCommand_Should_ReturnGuidOfTheEmailInHappyPath()
        {
            // Arrange
            var emailTemplateRepository = new Mock<IEmailTemplateRepository>();
            emailTemplateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult("test"));
            var emailRepository = new Mock<IEmailRepository>();
            var messageBus = new Mock<IMessageBus>();
            var handler = new SendEmailCommandHandler(emailTemplateRepository.Object, emailRepository.Object, messageBus.Object);

            // Act
            var guid = await handler.Handle(new SendEmailCommand(1, "test@test.com", "test"), CancellationToken.None);

            // Assert
            guid.Should().NotBeEmpty();
        }

        [Fact]
        public async Task SendEmailCommand_Should_StoreTheEmailIntoTheDB()
        {
            // Arrange
            var emailTemplateRepository = new Mock<IEmailTemplateRepository>();
            emailTemplateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult("test"));
            var emailRepository = new Mock<IEmailRepository>();
            var messageBus = new Mock<IMessageBus>();
            var handler = new SendEmailCommandHandler(emailTemplateRepository.Object, emailRepository.Object, messageBus.Object);

            // Act
            _ = await handler.Handle(new SendEmailCommand(1, "test@test.com", "test"), CancellationToken.None);

            // Assert
            emailRepository.Verify(x => x.Create(It.IsAny<Email>()), Times.Once());
        }

        [Fact]
        public async Task SendEmailCommand_Should_SendASendEmailWIthTemplateCommand()
        {
            // Arrange
            var emailTemplateRepository = new Mock<IEmailTemplateRepository>();
            emailTemplateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult("test"));
            var emailRepository = new Mock<IEmailRepository>();
            var messageBus = new Mock<IMessageBus>();
            var handler = new SendEmailCommandHandler(emailTemplateRepository.Object, emailRepository.Object, messageBus.Object);

            // Act
            _ = await handler.Handle(new SendEmailCommand(1, "test@test.com", "test"), CancellationToken.None);

            // Assert
            messageBus.Verify(x => x.Publish(It.IsAny<SendEmailWithTemplateCommand>()), Times.Once());
        }
    }
}