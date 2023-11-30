namespace UserManagementAPI.DTOs.Responses;

public class UserResponse
{
    public int UserId { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public bool IsActive { get; init; }

    public UserResponse(int userId, string username, string email, bool isActive)
    {
        UserId = userId;
        Username = username;
        Email = email;
        IsActive = isActive;
    }
}

