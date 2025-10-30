using Consultation.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Infrastructure.Data
{
    public class MigrationHelper
    {
        public static void ModelBuilderHelper(ModelBuilder builder)
        {

            builder.Entity<Faculty>().Property(f => f.FacultyID).ValueGeneratedNever();
            builder.Entity<Student>().Property(s => s.StudentID).ValueGeneratedNever();
            builder.Entity<ConsultationRequest>().Property(cr => cr.ConsultationID).ValueGeneratedNever();

            builder.Entity<ConsultationRequest>()
                .HasOne(cr => cr.Faculty)
                .WithMany(f => f.ConsultationRequests)
                .HasForeignKey(cr => cr.FacultyID)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<ConsultationRequest>()
                .HasOne(cr => cr.Student)
                .WithMany(s => s.ConsultationRequests)
                .HasForeignKey(cr => cr.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ConsultationRequest>()
                 .HasOne(cr => cr.Student)
                 .WithMany(s => s.ConsultationRequests)
                 .HasForeignKey(cr => cr.StudentID)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EnrolledCourse>()
                 .HasOne(ec => ec.SchoolYear)
                 .WithMany(sy => sy.EnrolledCourses)
                 .HasForeignKey(ec => ec.SchoolYearID)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EnrolledCourse>()
                  .HasOne(ec => ec.Student)
                  .WithMany(s => s.EnrolledCourses)
                  .HasForeignKey(ec => ec.StudentID)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Student>()
                        .Property(s => s.StudentID)
                        .ValueGeneratedOnAdd()
                        .UseMySqlIdentityColumn();

            builder.Entity<Faculty>()
                     .Property(s => s.FacultyID)
                     .ValueGeneratedOnAdd()
                     .UseMySqlIdentityColumn();

            builder.Entity<EnrolledCourse>()
                     .Property(s => s.EnrolledCourseID)
                     .ValueGeneratedOnAdd()
                     .UseMySqlIdentityColumn();

            builder.Entity<Program>()
                     .Property(s => s.ProgramID)
                     .ValueGeneratedOnAdd()
                     .UseMySqlIdentityColumn();

            builder.Entity<FacultySchedule>()
                     .Property(s => s.FacultyScheduleID)
                     .ValueGeneratedOnAdd()
                     .UseMySqlIdentityColumn();

            builder.Entity<SchoolYear>()
                     .Property(s => s.SchoolYearID)
                     .ValueGeneratedOnAdd()
                     .UseMySqlIdentityColumn();

            builder.Entity<Notification>()
                    .Property(s => s.NotificationNumber)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

            builder.Entity<ConsultationRequest>()
                    .Property(s => s.ConsultationID)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

            builder.Entity<Department>()
                    .Property(s => s.DepartmentID)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

            builder.Entity<Bulletin>()
                 .Property(s => s.BulletinID)
                 .ValueGeneratedOnAdd()
                 .UseMySqlIdentityColumn();

            builder.Entity<ActionLog>()
              .Property(s => s.ActionLogID)
              .ValueGeneratedOnAdd()
              .UseMySqlIdentityColumn();

            builder.Entity<Admin>()
             .Property(s => s.AdminID)
             .ValueGeneratedOnAdd()
             .UseMySqlIdentityColumn();

        }
    }
}
