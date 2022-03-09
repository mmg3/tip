using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TIP.Models;

namespace TIP.Contexts
{
    public partial class TIPContext : DbContext
    {
        public TIPContext()
        {
        }

        public TIPContext(DbContextOptions<TIPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_spanish_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.IdEnterprise, "fk_enterp_department");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IdEnterprise)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_enterprise");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .HasMaxLength(32)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.EnterpriseNav)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.IdEnterprise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_enterp_department");
            });

            modelBuilder.Entity<DepartmentEmployee>(entity =>
            {
                entity.ToTable("department_employee");

                entity.HasIndex(e => e.IdDepartment, "fk_dept_deptemployee");

                entity.HasIndex(e => e.IdEmployee, "fk_emp_deptemployee");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IdDepartment)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_department");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_employee");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("b'1'");

                entity.HasOne(d => d.DepartmentNav)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dept_deptemployee");

                entity.HasOne(d => d.EmployeeNav)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_deptemployee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Surname)
                    .HasMaxLength(64)
                    .HasColumnName("surname")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.ToTable("enterprise");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .HasColumnName("address")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .HasMaxLength(32)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("b'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
