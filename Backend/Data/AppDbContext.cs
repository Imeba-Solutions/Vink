using Microsoft.EntityFrameworkCore;
using Backend.Features.Shared;
using Backend.Features.Roles.Models;
using Backend.Features.Users.Models;
using Backend.Features.Patients.Models;
using Backend.Features.Appointments.Models;
using Backend.Features.MedicalRecords.Models;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserPersonalDataEntity> UserPersonalData { get; set; }
    public DbSet<PatientEntity> Patients { get; set; }
    public DbSet<PatientPersonalDataEntity> PatientPersonalData { get; set; }
    public DbSet<AppointmentStatusEntity> AppointmentStatuses { get; set; }
    public DbSet<AppointmentEntity> Appointments { get; set; }
    public DbSet<MedicalRecordEntity> MedicalRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Soft Delete Filters
        modelBuilder.Entity<UserEntity>().HasQueryFilter(e => e.DeletedAt == null);
        modelBuilder.Entity<PatientEntity>().HasQueryFilter(e => e.DeletedAt == null);
        modelBuilder.Entity<AppointmentEntity>().HasQueryFilter(e => e.DeletedAt == null);
        modelBuilder.Entity<MedicalRecordEntity>().HasQueryFilter(e => e.DeletedAt == null);

        // 1:1 Relationships
        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.PersonalData)
            .WithOne(p => p.User)
            .HasForeignKey<UserPersonalDataEntity>(p => p.UserId);

        modelBuilder.Entity<PatientEntity>()
            .HasOne(p => p.PersonalData)
            .WithOne(pd => pd.Patient)
            .HasForeignKey<PatientPersonalDataEntity>(pd => pd.PatientId);

        // Indexes
        modelBuilder.Entity<RoleEntity>().HasIndex(r => r.Name).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<UserPersonalDataEntity>().HasIndex(u => u.NationalId).IsUnique();
        modelBuilder.Entity<PatientPersonalDataEntity>().HasIndex(p => p.NationalId).IsUnique();
        modelBuilder.Entity<AppointmentStatusEntity>().HasIndex(a => a.StatusName).IsUnique();
    }

    public override int SaveChanges()
    {
        HandleAuditableEntities();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleAuditableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void HandleAuditableEntities()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is IAuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var auditable = (IAuditableEntity)entityEntry.Entity;
            auditable.UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                auditable.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}
