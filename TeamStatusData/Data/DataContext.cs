using Microsoft.EntityFrameworkCore;
using TeamStatusData.Enums;
using TeamStatusData.Models;

namespace TeamStatusData.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 2, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 3, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 4, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 5, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 6, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 7, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 8, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 9, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available},
            new User { Id = 10, Name = "McKenzie Powell", Title = "ISM Manager", Status = UserStatus.Available}
            );
    }
    
    public DbSet<User> Users { get; set; }
}