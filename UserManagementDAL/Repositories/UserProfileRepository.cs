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

    public async Task<IEnumerable<UserProfile>> GetActiveProfilesAsync()
    {
        return await _context.UserProfiles.Where(up => up.User.IsActive).ToListAsync();
    }
}

