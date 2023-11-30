using System.ComponentModel.DataAnnotations;

namespace UserManagementDAL.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(255)]
    public required string Username { get; set; }

    [Required]
    [StringLength(255)]
    public required string Password { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public bool IsActive { get; set; } = false;

    public virtual UserProfile UserProfile { get; set; }
}

