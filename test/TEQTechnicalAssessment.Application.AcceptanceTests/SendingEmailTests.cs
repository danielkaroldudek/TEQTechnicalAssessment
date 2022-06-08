using FluentAssertions;
using System;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;

namespace TEQTechnicalAssessment.Application.AcceptanceTests
{
    public class SendingEmailTests : BaseAcceptanceTest
    {
        private SendEmailCommand sendEmailCommand;
        private Guid sendEmailGuid;

        private void GivenIHaveValidSendEmailCommand() => sendEmailCommand = new SendEmailCommand(1, "test@test.com", "test");

        private async Task WhenICallTheMediatorWithThatCommand()
        {
            sendEmailGuid = await mediator.Send(sendEmailCommand);
        }

        private void ThenTheEmailShouldBeSent()
        {
            sendEmailGuid.Should().NotBeEmpty();
        }

        [Fact]
        public void SmsShouldBeSentSuccessfully()
        {
            this.Given(s => s.GivenIHaveValidSendEmailCommand())
                .When(s => s.WhenICallTheMediatorWithThatCommand())
                .Then(s => s.ThenTheEmailShouldBeSent())
                .BDDfy();
        }
    }
}