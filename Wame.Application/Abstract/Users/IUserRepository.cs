using Wame.Domain.Entities.Users;

namespace Wame.Application.Abstract.Users;

public interface IUserRepository
{
    Task<User?> FindByEmail(string email);

    Task<User?> Create(User user);
}