using System;
using Login.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Login.Data
{
    public partial class LocalTrainingContext : DbContext
    {
        public LocalTrainingContext()
        {
        }

        public LocalTrainingContext(DbContextOptions<LocalTrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Management> Managements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=LocalTraining;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AI");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MgtId).HasColumnName("MgtID");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.HasOne(d => d.Mgt)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.MgtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Management");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.ToTable("Employee");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<Management>(entity =>
            {
                entity.ToTable("Management");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OrdererId).HasColumnName("ordererId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
