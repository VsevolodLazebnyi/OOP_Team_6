using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Infrastructure.Persistence.Entity;

namespace RealEstatePortal.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() {}
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
        // Сюда добавлять различные конфигурации ваших файлов
        base.OnModelCreating(modelBuilder);
    }
}
