using Wame.Domain.Entities.Users;

namespace Wame.Application.Abstract.Users;

public interface ICandidateRepository
{
    Task<Candidate> GetCandidateByEmail(string candidateEmail);
}