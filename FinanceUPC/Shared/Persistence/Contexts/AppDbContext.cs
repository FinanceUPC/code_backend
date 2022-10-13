using Microsoft.EntityFrameworkCore;
using FinanceUPC.Security.Domain.Models;
using FinanceUPC.Shared.Extensions;

namespace FinanceUPC.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        
        //builder.Entity<User>()
        //    .HasMany(p => p.Projects)
        //    .WithOne(p => p.User)
        //    .HasForeignKey(p => p.UserId);
        //
        //builder.Entity<User>()
        //    .HasMany(p => p.Orders)
        //    .WithOne(p => p.User)
        //    .HasForeignKey(p => p.UserId);
        
        
        // Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();


    }
}