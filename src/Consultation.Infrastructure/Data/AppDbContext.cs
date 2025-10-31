using Consultation.Domain;
using Consultation.Domain.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Consultation.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext() : base()
        {
        }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
              
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection to Local SQL Server Database
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
 "Initial Catalog=ConsultationDatabase;" +
       "Integrated Security=True;Connect Timeout=30;" +
      "Encrypt=False;Trust Server Certificate=False;" +
     "Application Intent=ReadWrite;Multi Subnet Failover=False");

            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            MigrationHelper.ModelBuilderHelper(builder);

            builder.Entity<Users>().HasData(DatabaseSeederInfo.UserDataList());
            builder.Entity<Department>().HasData(DatabaseSeederInfo.DeparrmentDataList());
            builder.Entity<Program>().HasData(DatabaseSeederInfo.ProgramDataList());
            builder.Entity<SchoolYear>().HasData(DatabaseSeederInfo.SchoolYearDataList());
            builder.Entity<EnrolledCourse>().HasData(DatabaseSeederInfo.EnrolledCourseDataList());
            builder.Entity<Student>().HasData(DatabaseSeederInfo.StudentDataList());
            builder.Entity<Faculty>().HasData(DatabaseSeederInfo.FacultyDataList());
            builder.Entity<Admin>().HasData(DatabaseSeederInfo.AdminDataList());
            builder.Entity<ConsultationRequest>().HasData(DatabaseSeederInfo.ConsultationRequestDataList());
            builder.Entity<FacultySchedule>().HasData(DatabaseSeederInfo.FacultyScheduleSeeder());
            builder.Entity<Notification>().HasData(DatabaseSeederInfo.NotificationSeeder());
        }

        public DbSet<ActionLog> ActionLog { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Bulletin> Bulletin { get; set; }
        public DbSet<ConsultationRequest> ConsultationRequest { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EnrolledCourse> EnrolledCourse { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Program> Program { get; set; }
        public DbSet<SchoolYear> SchoolYear { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
