using Microsoft.EntityFrameworkCore;
using UserManagementDAL.Data;
using UserManagementDAL.Entities;
using UserManagementDAL.Interfaces;

namespace UserManagementDAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(UserManagementContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}

