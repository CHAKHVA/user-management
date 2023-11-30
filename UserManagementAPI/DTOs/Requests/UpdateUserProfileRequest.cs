namespace UserManagementAPI.DTOs.Requests;

public record UpdateUserProfileRequest(string? FirstName, string? LastName, string? PersonalNumber);
