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
            new User { Id = 2, Name = "Sakura Crandall", Title = "ISM", Status = UserStatus.Break},
            new User { Id = 3, Name = "Brittany Mercedes", Title = "ISM", Status = UserStatus.Available},
            new User { Id = 4, Name = "Ryan Vidlak", Title = "ISM", Status = UserStatus.Available},
            new User { Id = 5, Name = "Grace le Bleu", Title = "ISM", Status = UserStatus.Available},
            new User { Id = 6, Name = "Dan Walls", Title = "ISM", Status = UserStatus.Offline},
            new User { Id = 7, Name = "Tim O'Malley", Title = "Sales Manager III", Status = UserStatus.Meeting},
            new User { Id = 8, Name = "Daniel Clogston", Title = "Sales Manager III", Status = UserStatus.Meeting},
            new User { Id = 9, Name = "Sam Mowrer", Title = "Pretend ISM", Status = UserStatus.Away},
            new User { Id = 10, Name = "Kingsley Adragna", Title = "ISM", Status = UserStatus.Lunch}
            );
    }
    
    public DbSet<User> Users { get; set; }
}