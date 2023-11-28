using UserManagementBLL.Interfaces;
using UserManagementDAL.Entities;
using UserManagementDAL.Interfaces;

namespace UserManagementBLL.Services;

public class UserProfileService : Service<UserProfile>, IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileService(IUserProfileRepository userProfileRepository) : base(userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<IEnumerable<UserProfile>> GetActiveProfilesAsync()
    {
        return await _userProfileRepository.GetActiveProfilesAsync();
    }
}

