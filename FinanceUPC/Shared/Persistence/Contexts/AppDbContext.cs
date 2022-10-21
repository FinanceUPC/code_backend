using FinanceUPC.Functions.Domain.Models;
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
    public DbSet<Methods> Methods { get; set; }
    public DbSet<German> Germans { get; set; }
    public DbSet<Conversion> Conversions { get; set; }
    public DbSet<Values> Values { get; set; }

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
        
        builder.Entity<User>()
            .HasMany(p => p.Methods)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<Methods>().ToTable("Methods");
        builder.Entity<Methods>().HasKey(p => p.Id);
        builder.Entity<Methods>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Methods>().Property(p => p.Type).IsRequired().HasMaxLength(50);
        builder.Entity<Methods>().Property(p => p.UserId).IsRequired();

        builder.Entity<Methods>()
            .HasMany(p => p.German)
            .WithOne(p => p.Methods)
            .HasForeignKey(p => p.MethodId);
        
        builder.Entity<German>().ToTable("Germans");
        builder.Entity<German>().HasKey(p => p.Id);
        builder.Entity<German>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<German>().Property(p => p.Amount).IsRequired().HasMaxLength(50);
        builder.Entity<German>().Property(p => p.MonthlyInterest).IsRequired();
        builder.Entity<German>().Property(p => p.InterestRate).IsRequired();
        builder.Entity<German>().Property(p => p.Period).IsRequired();
        builder.Entity<German>().Property(p => p.MethodId).IsRequired();

        builder.Entity<Methods>()
            .HasMany(p => p.Conversion)
            .WithOne(p => p.Methods)
            .HasForeignKey(p => p.MethodId);
        
        builder.Entity<Conversion>().ToTable("Conversions");
        builder.Entity<Conversion>().HasKey(p => p.Id);
        builder.Entity<Conversion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Conversion>().Property(p => p.Type).IsRequired().HasMaxLength(50);
        builder.Entity<Conversion>().Property(p => p.DaysAYear).IsRequired();
        builder.Entity<Conversion>().Property(p => p.NominalRate).IsRequired();
        builder.Entity<Conversion>().Property(p => p.NominalRateTerm).IsRequired();
        builder.Entity<Conversion>().Property(p => p.CapitalizationPeriod).IsRequired();
        builder.Entity<Conversion>().Property(p => p.EffectiveRateRequired).IsRequired();
        builder.Entity<Conversion>().Property(p => p.Result).IsRequired();
        builder.Entity<Conversion>().Property(p => p.MethodId).IsRequired();

        builder.Entity<Methods>()
            .HasMany(p => p.Values)
            .WithOne(p => p.Methods)
            .HasForeignKey(p => p.MethodId);
        
        builder.Entity<Values>().ToTable("Values");
        builder.Entity<Values>().HasKey(p => p.Id);
        builder.Entity<Values>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Values>().Property(p => p.ExchangeRate).IsRequired().HasMaxLength(50);
        builder.Entity<Values>().Property(p => p.FutureValue).IsRequired();
        builder.Entity<Values>().Property(p => p.EffectiveRateTerm).IsRequired();
        builder.Entity<Values>().Property(p => p.EffectiveRate).IsRequired();
        builder.Entity<Values>().Property(p => p.InitialDate).IsRequired();
        builder.Entity<Values>().Property(p => p.FinalDate).IsRequired();
        builder.Entity<Values>().Property(p => p.Result).IsRequired();
        builder.Entity<Values>().Property(p => p.MethodId).IsRequired();

        // Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();


    }
}