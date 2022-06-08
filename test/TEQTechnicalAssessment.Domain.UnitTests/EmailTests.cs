using FluentAssertions;
using System;
using TEQTechnicalAssessment.Domain.Entities;
using Xunit;

namespace TEQTechnicalAssessment.Domain.UnitTests
{
    public class EmailTests
    {
        [Fact]
        public void EmailObject_ShouldNotThrow_ForValidInitialValues()
        {
            // Arrange & Act
            Action act = () => new Email(1, "test", "test","test@test.com", Enums.EmailStatus.ToBeSent);

            // Assert
            // TODO: Introduce domain exceptions
            //act.Should().NotThrow<EmailNotCorrectException>();
        }

        [Fact]
        public void EmailObject_ShouldThrowArgumentNullException_ForInValidInitialValues()
        {
            // Arrange & Act
            Action act = () => new Email(1, "test", "test", "ERROR", Enums.EmailStatus.ToBeSent);

            // Assert
            // TODO: Introduce domain exceptions
            //act.Should().Throw<EmailNotCorrectException>();
        }
    }
}