#pragma warning disable CA1720
#pragma warning disable SA1206

using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Infrastructure.Persistence.Entity;

namespace RealEstatePortal.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public required DbSet<DealEntity> Deal { get; set; }

    public required DbSet<DealStatusEntity> DealStatus { get; set; }

    public required DbSet<ObjectEntity> Object { get; set; }

    public required DbSet<ObjectStatusEntity> ObjectStatus { get; set; }

    public required DbSet<ReviewEntity> Review { get; set; }

    public required DbSet<RoleEntity> Role { get; set; }

    public required DbSet<UserEntity> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<DealEntity>().ToTable("Deal", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<DealStatusEntity>().ToTable("DealStatus", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ObjectEntity>().ToTable("Object", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ObjectStatusEntity>().ToTable("ObjectStatus", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<ReviewEntity>().ToTable("Review", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<RoleEntity>().ToTable("Role", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<UserEntity>().ToTable("User", t => t.ExcludeFromMigrations());
        base.OnModelCreating(modelBuilder);
    }
}
