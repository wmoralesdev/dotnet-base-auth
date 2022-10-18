using Wame.Domain.Entities.Users;

namespace Wame.Application.Abstract.Users;

public interface IRecruiterRepository
{
    Task<Recruiter> CreateRecruiter(Recruiter recruiter, int companyId);
}