using UserManagementDAL.Entities;

namespace UserManagementBLL.Interfaces;

public interface IUserProfileService : IService<UserProfile>
{
    Task<IEnumerable<UserProfile>> GetActiveUserProfilesAsync();
}

