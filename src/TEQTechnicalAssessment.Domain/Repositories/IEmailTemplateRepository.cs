namespace TEQTechnicalAssessment.Domain.Repositories
{
    public interface IEmailTemplateRepository
    {
        Task<string> Get(int templateId);
    }
}
