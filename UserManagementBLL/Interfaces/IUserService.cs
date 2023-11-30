using UserManagementDAL.Entities;

namespace UserManagementBLL.Interfaces;

public interface IUserService : IService<User>
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> ValidateUser(string username, string password);
}

