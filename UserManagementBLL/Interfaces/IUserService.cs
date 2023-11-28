using UserManagementDAL.Entities;

namespace UserManagementBLL.Interfaces;

public interface IUserService : IService<User>
{
    Task<User> GetUserByEmailAsync(string email);
}

