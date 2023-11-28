using Microsoft.EntityFrameworkCore;
using UserManagementDAL.Entities;

namespace UserManagementDAL.Data;

public class UserManagementContext : DbContext
{
	public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
	{
	}

	public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserProfile)
            .WithOne(up => up.User)
            .HasForeignKey<UserProfile>(up => up.UserId);
    }
}

