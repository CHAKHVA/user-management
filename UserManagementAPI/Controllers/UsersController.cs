using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.DTOs.Requests;
using UserManagementAPI.DTOs.Responses;
using UserManagementBLL.Interfaces;
using UserManagementBLL.Utilities;
using UserManagementDAL.Entities;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            var userResponses = users.Select(user => new UserResponse(user.UserId, user.Username, user.Email, user.IsActive));
            return Ok(userResponses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all users");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userResponse = new UserResponse(user.UserId, user.Username, user.Email, user.IsActive);
            return Ok(userResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while retrieving user with ID {id}");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = PasswordHasher.HashPassword(request.Password),
                IsActive = request.IsActive
            };

            await _userService.CreateAsync(user);
            var response = new UserResponse(user.UserId, user.Username, user.Email, user.IsActive);

            return CreatedAtAction(nameof(GetUserById), new { id = response.UserId }, response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating a new user");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = request.Email ?? user.Email;
            if (request.Password != null)
                user.Password = PasswordHasher.HashPassword(request.Password);
            user.IsActive = request.IsActive ?? user.IsActive;

            await _userService.UpdateAsync(user);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating user with ID {id}");
            return StatusCode(500, "An internal error occurred");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting user with ID {id}");
            return StatusCode(500, "An internal error occurred");
        }
    }
}

