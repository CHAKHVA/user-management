using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.DTOs.Requests;

public record CreateUserProfileRequest(
    [Required]
    [StringLength(255)]
    string FirstName,

    [Required]
    [StringLength(255)]
    string LastName,

    [Required]
    [StringLength(11, MinimumLength = 11)]
    string PersonalNumber,

    int UserId);
