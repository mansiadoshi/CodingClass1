using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingClass_7_3_2019
{
    class CodingClassContext : DbContext
    {
        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<StudentCourseHistory> StudentHistory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CodingClass_1stProject;Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAccount>(e =>
            {
                e.HasKey(a => a.StudentAccountNumber).HasName("PK_AccountNumber");
                e.ToTable("StudentAccounts");
                e.Property(a => a.StudentAccountNumber).ValueGeneratedOnAdd();
                e.Property(a => a.StudentEmailAddress).IsRequired().HasMaxLength(100);
                e.Property(a => a.StudentDifficultyLevel).IsRequired();
                e.Property(a => a.StudentClassType).IsRequired();
            }
                );

            modelBuilder.Entity<StudentCourseHistory>(e =>
            {
                e.ToTable("StudentHistory");
                e.HasKey(h => h.CourseHistoryID).HasName("PK_CourseHistoryID");
                e.Property(h => h.ClassesEnrolledFor).IsRequired();
                e.HasOne(h => h.account).WithMany().HasForeignKey(h => h.AccountNumber);
            }
                );
        }
    }
}
