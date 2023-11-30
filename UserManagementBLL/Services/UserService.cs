using UserManagementBLL.Interfaces;
using UserManagementBLL.Utilities;
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

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _userRepository.GetUserByUsernameAsync(username);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }

    public async Task<User?> ValidateUser(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user != null && PasswordHasher.VerifyPassword(password, user.Password))
        {
            return user;
        }
        return null;
    }
}

