using TEQTechnicalAssessment.Domain.Repositories;

namespace TEQTechnicalAssessment.Stubs
{
    public class EmailTemplateRepositoryStub : IEmailTemplateRepository
    {
        public Task<string> Get(int templateId) => Task.FromResult("test");
    }
}
