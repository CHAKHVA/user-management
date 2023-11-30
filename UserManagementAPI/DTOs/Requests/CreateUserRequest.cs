using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.DTOs.Requests;

public record CreateUserRequest(
    [Required]
    [StringLength(255)]
    string Username,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    [StringLength(255)]
    string Password,

    bool IsActive = false);
