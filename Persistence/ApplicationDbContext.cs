namespace Persistence;


using Microsoft.EntityFrameworkCore;

using Base.Tools;
using System.Diagnostics;

/// <summary>
/// TODO
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {
        //We need this constructor for migration
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //TODO
    //public DbSet<EntityName> EntityName => Set<EntityName>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //We need this for migration
            string connectionString = ConfigurationHelper.GetConfiguration().Get("DefaultConnection", "ConnectionStrings");
            optionsBuilder.UseSqlServer(connectionString);
        }
        optionsBuilder.LogTo(message => Debug.WriteLine(message));
}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //TODO
        /*modelBuilder.Entity<EntityName>()
            .HasOne(p => p.EntityName).WithMany()
            .HasForeignKey(p => p.EntityName)
            .OnDelete(DeleteBehavior.ClientNoAction);*/
    }
}