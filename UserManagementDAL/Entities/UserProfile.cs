using System.ComponentModel.DataAnnotations;

namespace UserManagementDAL.Entities;

public class UserProfile
{
    [Key]
    public int UserProfileId { get; set; }

    [Required]
    [StringLength(255)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(255)]
    public string LastName { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string PersonalNumber { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
}

