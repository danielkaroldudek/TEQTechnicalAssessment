using TEQTechnicalAssessment.Domain.Entities;

namespace TEQTechnicalAssessment.Domain.Repositories
{
    public interface IEmailRepository
    {
        Task Create(Email email);
    }
}
