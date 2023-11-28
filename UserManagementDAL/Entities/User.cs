using System.ComponentModel.DataAnnotations;

namespace UserManagementDAL.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(255)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public bool IsActive { get; set; }

    public virtual UserProfile UserProfile { get; set; }
}

