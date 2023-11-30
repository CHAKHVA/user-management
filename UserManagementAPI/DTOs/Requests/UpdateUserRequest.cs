namespace UserManagementAPI.DTOs.Requests;

public record UpdateUserRequest(string? Email, string? Password, bool? IsActive);
