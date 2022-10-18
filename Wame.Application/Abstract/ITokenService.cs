using Wame.Domain.Entities.Users;

namespace Wame.Application.Abstract;

public interface ITokenService
{
    string GenerateToken(User user);
}