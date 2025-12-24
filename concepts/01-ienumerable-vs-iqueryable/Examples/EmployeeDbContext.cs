using Microsoft.EntityFrameworkCore;

namespace NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;

/// <summary>
/// DbContext de ejemplo para demostrar IQueryable con Entity Framework
/// </summary>
public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpID);
            entity.Property(e => e.EmpName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Department).HasMaxLength(50);
        });
    }
}

