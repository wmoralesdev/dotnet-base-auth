using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Abstract.Tokens;

public interface ITokenService
{
    string GenerateToken(BaseIdentity candidate);
}