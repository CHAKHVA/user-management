using Microsoft.EntityFrameworkCore;
using UserManagementDAL.Data;
using UserManagementDAL.Entities;
using UserManagementDAL.Interfaces;

namespace UserManagementDAL.Repositories;

public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(UserManagementContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserProfile>> GetActiveProfiles()
    {
        return await _context.UserProfiles.Where(up => up.IsActive).ToListAsync();
    }
}

