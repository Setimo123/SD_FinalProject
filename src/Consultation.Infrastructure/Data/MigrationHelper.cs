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
        }
    }
}
