
global using Microsoft.EntityFrameworkCore;


namespace DeptEmp.Models;

public class SiteDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
     public DbSet<Department> Departments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Employee.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
                    .ToTable("R71_Employee")
                    .Property(y => y.Id)
                    .HasColumnName("Empno");

        modelBuilder.Entity<Employee>()
                    .ToTable("R71_Employee")
                    .Property(y => y.Ename)
                    .HasColumnName("ename");

        modelBuilder.Entity<Employee>()
                    .ToTable("R71_Employee")
                    .Property(y => y.DepartmentId)
                    .HasColumnName("deptno");
    }

    

}