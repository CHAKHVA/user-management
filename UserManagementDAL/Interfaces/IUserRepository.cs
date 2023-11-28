using UserManagementDAL.Entities;

namespace UserManagementDAL.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}

