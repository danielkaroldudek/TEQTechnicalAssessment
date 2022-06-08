using TEQTechnicalAssessment.Domain.Entities;
using TEQTechnicalAssessment.Domain.Repositories;

namespace TEQTechnicalAssessment.Stubs
{
    public class EmailRepositoryStub : IEmailRepository
    {
        public Task Create(Email email) => Task.CompletedTask;
    }
}
