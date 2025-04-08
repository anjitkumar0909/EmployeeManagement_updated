using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Employee_erp.Models
{
    public class EMPLOYEE_DBContext : DbContext 
    {
        public EMPLOYEE_DBContext()
        {
        }

        public EMPLOYEE_DBContext(DbContextOptions<EMPLOYEE_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                //entity.ToTable("Employee");

                //entity.Property(e => e.FirstName).HasMaxLength(100);

                //entity.Property(e => e.LastName).HasMaxLength(100);

                //entity.HasOne(d => d.Department)
                //    .WithMany(p => p.Employees)
                //    .HasForeignKey(d => d.DepartmentId)
                //    .HasConstraintName("FK_Employee_Department");

                 entity.HasOne(e => e.Department)
        .WithMany(d => d.Employees)
        .HasForeignKey(e => e.DepartmentId)
        .OnDelete(DeleteBehavior.SetNull);

            });

           // OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
