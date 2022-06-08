namespace TEQTechnicalAssessment.Domain.Commands
{
    public record SendEmailWithTemplateCommand(string Title, string To, string Message);
}
