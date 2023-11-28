using UserManagementBLL.Interfaces;
using UserManagementDAL.Entities;
using UserManagementDAL.Interfaces;

namespace UserManagementBLL.Services;

public class UserService : Service<User>, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }
}

