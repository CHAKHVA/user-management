using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.DTOs.Requests;
using UserManagementAPI.DTOs.Responses;
using UserManagementBLL.Interfaces;
using UserManagementDAL.Entities;

namespace UserManagementAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly ILogger<UserProfileController> _logger;

    public UserProfileController(IUserProfileService userProfileService, ILogger<UserProfileController> logger)
    {
        _userProfileService = userProfileService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserProfiles()
    {
        try
        {
            var userProfiles = await _userProfileService.GetAllAsync();
            var userProfleResponses = userProfiles.Select(userProfile => new UserProfileResponse(userProfile.UserProfileId, userProfile.FirstName, userProfile.LastName, userProfile.PersonalNumber, userProfile.UserId));
            return Ok(userProfleResponses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all user profiles");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserProfileById(int id)
    {
        try
        {
            var userProfile = await _userProfileService.GetByIdAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            var response = new UserProfileResponse(userProfile.UserProfileId, userProfile.FirstName, userProfile.LastName, userProfile.PersonalNumber, userProfile.UserId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while retrieving user profile with ID {id}");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileRequest request)
    {
        try
        {
            var userProfile = new UserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalNumber = request.PersonalNumber,
                UserId = request.UserId
            };

            await _userProfileService.CreateAsync(userProfile);
            var response = new UserProfileResponse(userProfile.UserProfileId, userProfile.FirstName, userProfile.LastName, userProfile.PersonalNumber, userProfile.UserId);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.UserId }, response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating user profile");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserProfile(int id, [FromBody] UpdateUserProfileRequest request)
    {
        try
        {
            var userProfile = await _userProfileService.GetByIdAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            userProfile.FirstName = request.FirstName ?? userProfile.FirstName;
            userProfile.LastName = request.LastName ?? userProfile.FirstName;
            userProfile.PersonalNumber = request.PersonalNumber ?? userProfile.PersonalNumber;

            await _userProfileService.UpdateAsync(userProfile);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating user profile with ID {id}");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        try
        {
            var userProfile = await _userProfileService.GetByIdAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            await _userProfileService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting user profile with ID {id}");
            return StatusCode(500, "An internal error occurred");
        }
    }
}
