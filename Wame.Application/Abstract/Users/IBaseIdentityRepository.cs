using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Abstract.Users;

public interface IBaseIdentityRepository
{
    Task<BaseIdentity?> GetIdentityByEmail(string email);
    
    Task<Recruiter> CreateRecruiter(Recruiter recruiter);
}