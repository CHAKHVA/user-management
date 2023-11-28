using UserManagementDAL.Entities;

namespace UserManagementDAL.Interfaces;

public interface IUserProfileRepository : IRepository<UserProfile>
{
    Task<IEnumerable<UserProfile>> GetActiveProfilesAsync();
}

