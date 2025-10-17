using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Consultation.App.Services
{
    /// <summary>
    /// Service for managing user data operations
    /// </summary>
    public class UserService
    {
        private static UserService _instance;
        private static readonly object _lock = new object();

        private UserService()
        {
        }

        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserService();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Gets a user by their UMID with full information
        /// </summary>
        public async Task<Users> GetUserByUMID(string umid)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = await context.Users
                        .AsNoTracking() // Read-only query for better performance
                        .FirstOrDefaultAsync(u => u.UMID == umid);
                    
                    if (user != null)
                    {
                        Console.WriteLine($"Successfully retrieved user: {user.UserName} (UMID: {umid})");
                    }
                    else
                    {
                        Console.WriteLine($"User with UMID {umid} not found");
                    }
                    
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUserByUMID Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return null;
            }
        }

        /// <summary>
        /// Updates user information in the database
        /// </summary>
        public async Task<bool> UpdateUser(string originalUMID, string newFullName, string newEmail, string newUMID, UserType newUserType, int? newDepartmentId = null)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Start a transaction to ensure all changes are saved together
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Find the user by original UMID
                            var user = await context.Users.FirstOrDefaultAsync(u => u.UMID == originalUMID);
                            if (user == null)
                            {
                                Console.WriteLine($"User with UMID {originalUMID} not found");
                                return false;
                            }

                            // Store the UsersID for updating related tables
                            string userId = user.Id;

                            // Update Users table
                            user.UserName = newFullName;
                            user.NormalizedUserName = newFullName.ToUpper();
                            user.Email = newEmail;
                            user.NormalizedEmail = newEmail.ToUpper();
                            user.UMID = newUMID;
                            user.UserType = newUserType;

                            // Mark user as modified
                            context.Entry(user).State = EntityState.Modified;

                            // Update related tables based on UserType
                            if (newUserType == UserType.Student)
                            {
                                var student = await context.Students
                                    .FirstOrDefaultAsync(s => s.UsersID == userId);
                                
                                if (student != null)
                                {
                                    student.StudentName = newFullName;
                                    student.Email = newEmail;
                                    student.StudentUMID = newUMID;
                                    
                                    if (newDepartmentId.HasValue)
                                    {
                                        student.ProgramID = newDepartmentId.Value;
                                    }
                                    
                                    context.Entry(student).State = EntityState.Modified;
                                }
                            }
                            else if (newUserType == UserType.Faculty)
                            {
                                var faculty = await context.Faculty
                                    .FirstOrDefaultAsync(f => f.UsersID == userId);
                                
                                if (faculty != null)
                                {
                                    faculty.FacultyName = newFullName;
                                    faculty.FacultyUMID = newUMID;
                                    
                                    context.Entry(faculty).State = EntityState.Modified;
                                }
                            }
                            else if (newUserType == UserType.Admin)
                            {
                                var admin = await context.Admin
                                    .FirstOrDefaultAsync(a => a.UsersID == userId);
                                
                                if (admin != null)
                                {
                                    admin.AdminName = newFullName;
                                    
                                    context.Entry(admin).State = EntityState.Modified;
                                }
                            }

                            // Save all changes
                            int changes = await context.SaveChangesAsync();
                            
                            // Commit transaction
                            await transaction.CommitAsync();
                            
                            Console.WriteLine($"Successfully updated user {originalUMID}. Changes saved: {changes}");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on error
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Transaction failed: {ex.Message}");
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateUser Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        /// <summary>
        /// Gets all departments for dropdown
        /// </summary>
        public async Task<List<Department>> GetAllDepartments()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return await context.Department.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllDepartments Error: {ex.Message}");
                return new List<Department>();
            }
        }

        /// <summary>
        /// Gets all programs for a specific department
        /// </summary>
        public async Task<List<Domain.Program>> GetProgramsByDepartment(int departmentId)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return await context.Program
                        .Where(p => p.DepartmentID == departmentId)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetProgramsByDepartment Error: {ex.Message}");
                return new List<Domain.Program>();
            }
        }

        /// <summary>
        /// Gets student information including department/program
        /// </summary>
        public async Task<(int? programId, string departmentName)> GetStudentDepartmentInfo(string umid)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var student = await context.Students
                        .AsNoTracking()
                        .Include(s => s.Program)
                        .ThenInclude(p => p.Department)
                        .FirstOrDefaultAsync(s => s.StudentUMID == umid);

                    if (student != null && student.Program != null)
                    {
                        Console.WriteLine($"Student department info: ProgramID={student.ProgramID}, Department={student.Program.Department?.DepartmentName}");
                        return (student.ProgramID, student.Program.Department?.DepartmentName ?? "N/A");
                    }

                    Console.WriteLine($"No student found with UMID: {umid}");
                    return (null, "N/A");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetStudentDepartmentInfo Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return (null, "N/A");
            }
        }

        /// <summary>
        /// Gets faculty department information
        /// </summary>
        public async Task<string> GetFacultyDepartmentInfo(string umid)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var faculty = await context.Faculty
                        .AsNoTracking()
                        .Include(f => f.SchoolYear)
                        .FirstOrDefaultAsync(f => f.FacultyUMID == umid);

                    return "Faculty Department"; // You can expand this based on your schema
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetFacultyDepartmentInfo Error: {ex.Message}");
                return "N/A";
            }
        }

        /// <summary>
        /// Verifies that a user update was successful by checking the database
        /// </summary>
        public async Task<bool> VerifyUserUpdate(string umid, string expectedName, string expectedEmail)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = await context.Users
                        .AsNoTracking()
                        .FirstOrDefaultAsync(u => u.UMID == umid);
                    
                    if (user == null)
                    {
                        Console.WriteLine($"Verification failed: User with UMID {umid} not found");
                        return false;
                    }

                    bool nameMatches = user.UserName == expectedName;
                    bool emailMatches = user.Email == expectedEmail;

                    Console.WriteLine($"Verification for UMID {umid}:");
                    Console.WriteLine($"  Expected Name: {expectedName}, Actual: {user.UserName}, Match: {nameMatches}");
                    Console.WriteLine($"  Expected Email: {expectedEmail}, Actual: {user.Email}, Match: {emailMatches}");

                    return nameMatches && emailMatches;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"VerifyUserUpdate Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes a user completely from the database including all related records
        /// </summary>
        public async Task<bool> DeleteUser(string umid)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Start a transaction to ensure all deletions are atomic
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Find the user by UMID
                            var user = await context.Users.FirstOrDefaultAsync(u => u.UMID == umid);
                            if (user == null)
                            {
                                Console.WriteLine($"User with UMID {umid} not found");
                                return false;
                            }

                            string userId = user.Id;
                            UserType userType = user.UserType;

                            // Delete related records based on UserType
                            if (userType == UserType.Student)
                            {
                                // Delete student record
                                var student = await context.Students
                                    .FirstOrDefaultAsync(s => s.UsersID == userId);
                                
                                if (student != null)
                                {
                                    // Delete enrolled courses for this student
                                    var enrolledCourses = await context.EnrolledCourse
                                        .Where(ec => ec.StudentID == student.StudentID)
                                        .ToListAsync();
                                    
                                    if (enrolledCourses.Any())
                                    {
                                        context.EnrolledCourse.RemoveRange(enrolledCourses);
                                    }
                                    
                                    // Delete consultation requests for this student
                                    var consultations = await context.ConsultationRequest
                                        .Where(cr => cr.StudentID == student.StudentID)
                                        .ToListAsync();
                                    
                                    if (consultations.Any())
                                    {
                                        context.ConsultationRequest.RemoveRange(consultations);
                                    }
                                    
                                    context.Students.Remove(student);
                                }
                            }
                            else if (userType == UserType.Faculty)
                            {
                                // Delete faculty record
                                var faculty = await context.Faculty
                                    .FirstOrDefaultAsync(f => f.UsersID == userId);
                                
                                if (faculty != null)
                                {
                                    // Delete or update consultation requests assigned to this faculty
                                    var consultations = await context.ConsultationRequest
                                        .Where(cr => cr.FacultyID == faculty.FacultyID)
                                        .ToListAsync();
                                    
                                    if (consultations.Any())
                                    {
                                        // Option 1: Delete consultations
                                        context.ConsultationRequest.RemoveRange(consultations);
                                        
                                        // Option 2: Set faculty to null (uncomment if preferred)
                                        // foreach (var consultation in consultations)
                                        // {
                                        //     consultation.FacultyID = null;
                                        // }
                                    }
                                    
                                    context.Faculty.Remove(faculty);
                                }
                            }
                            else if (userType == UserType.Admin)
                            {
                                // Delete admin record
                                var admin = await context.Admin
                                    .FirstOrDefaultAsync(a => a.UsersID == userId);
                                
                                if (admin != null)
                                {
                                    context.Admin.Remove(admin);
                                }
                            }

                            // Delete action logs related to this user
                            var actionLogs = await context.ActionLog
                                .Where(al => al.Users.Id == userId)
                                .ToListAsync();
                            
                            if (actionLogs.Any())
                            {
                                context.ActionLog.RemoveRange(actionLogs);
                            }

                            // Finally, delete the user from Users table
                            context.Users.Remove(user);

                            // Save all changes
                            int changes = await context.SaveChangesAsync();
                            
                            // Commit transaction
                            await transaction.CommitAsync();
                            
                            Console.WriteLine($"Successfully deleted user {umid} and all related records. Changes saved: {changes}");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on error
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Transaction failed during delete: {ex.Message}");
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteUser Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        /// <summary>
        /// Creates a new user in the system with the specified information
        /// </summary>
        public async Task<bool> CreateUser(
            string fullName,
            string email,
            string umid,
            string password,
            UserType userType,
            int? departmentId = null)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Start a transaction to ensure all changes are saved together
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Check if UMID already exists
                            var existingUser = await context.Users
                                .FirstOrDefaultAsync(u => u.UMID == umid);
                            
                            if (existingUser != null)
                            {
                                Console.WriteLine($"User with UMID {umid} already exists");
                                MessageBox.Show(
                                    $"A user with UMID {umid} already exists in the system.",
                                    "Duplicate UMID",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return false;
                            }

                            // Check if email already exists
                            var existingEmail = await context.Users
                                .FirstOrDefaultAsync(u => u.Email == email);
                            
                            if (existingEmail != null)
                            {
                                Console.WriteLine($"User with email {email} already exists");
                                MessageBox.Show(
                                    $"A user with email {email} already exists in the system.",
                                    "Duplicate Email",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return false;
                            }

                            // Create new Users instance
                            var newUser = new Users
                            {
                                Id = Guid.NewGuid().ToString().ToUpper(),
                                UserName = fullName,
                                NormalizedUserName = fullName.ToUpper(),
                                Email = email,
                                NormalizedEmail = email.ToUpper(),
                                EmailConfirmed = true,
                                UMID = umid,
                                UserType = userType,
                                SecurityStamp = Guid.NewGuid().ToString(),
                                ConcurrencyStamp = Guid.NewGuid().ToString(),
                                PhoneNumber = null, // No phone number field anymore
                                PhoneNumberConfirmed = false,
                                LockoutEnabled = false,
                                TwoFactorEnabled = false,
                                AccessFailedCount = 0
                            };

                            // Hash the password using Identity's PasswordHasher
                            var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<Users>();
                            newUser.PasswordHash = passwordHasher.HashPassword(newUser, password);

                            // Add user to database
                            context.Users.Add(newUser);
                            await context.SaveChangesAsync();

                            Console.WriteLine($"Created user: {newUser.UserName} with ID: {newUser.Id}");

                            // Get the current school year (default to first school year)
                            var currentSchoolYear = await context.SchoolYear
                                .FirstOrDefaultAsync(sy => sy.SchoolYearStatus == Domain.Enum.SchoolYearStatus.Current);
                            
                            int schoolYearId = currentSchoolYear?.SchoolYearID ?? 1;

                            // Create related records based on UserType
                            if (userType == UserType.Student)
                            {
                                // Ensure department/program ID is provided for students
                                if (!departmentId.HasValue)
                                {
                                    Console.WriteLine("Program ID is required for students");
                                    await transaction.RollbackAsync();
                                    MessageBox.Show(
                                        "Program/Department is required for student registration.",
                                        "Missing Information",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return false;
                                }

                                var newStudent = new Student
                                {
                                    StudentUMID = umid,
                                    StudentName = fullName,
                                    Email = email,
                                    ProgramID = departmentId.Value,
                                    SchoolYearID = schoolYearId,
                                    UsersID = newUser.Id
                                };

                                context.Students.Add(newStudent);
                                Console.WriteLine($"Created student record for {fullName}");
                            }
                            else if (userType == UserType.Faculty)
                            {
                                // For faculty, we should set a default program or make it optional
                                // If no department is selected, use the first available program
                                int facultyProgramId = departmentId ?? 1; // Default to first program if not specified
                                
                                var newFaculty = new Faculty
                                {
                                    FacultyUMID = umid,
                                    FacultyName = fullName,
                                    SchoolYearID = schoolYearId,
                                    UsersID = newUser.Id,
                                    ProgramID = facultyProgramId, // Set the ProgramID for faculty
                                    FacultyEmail = email // Set email for faculty
                                };

                                context.Faculty.Add(newFaculty);
                                Console.WriteLine($"Created faculty record for {fullName}");
                            }
                            else if (userType == UserType.Admin)
                            {
                                var newAdmin = new Admin
                                {
                                    AdminName = fullName,
                                    UsersID = newUser.Id
                                };

                                context.Admin.Add(newAdmin);
                                Console.WriteLine($"Created admin record for {fullName}");
                            }

                            // Save all changes
                            int changes = await context.SaveChangesAsync();

                            // Commit transaction
                            await transaction.CommitAsync();

                            Console.WriteLine($"Successfully created user {umid}. Total changes saved: {changes}");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on error
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Transaction failed during user creation: {ex.Message}");
                            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateUser Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a UMID is already in use
        /// </summary>
        public async Task<bool> IsUMIDAvailable(string umid)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var exists = await context.Users.AnyAsync(u => u.UMID == umid);
                    return !exists;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IsUMIDAvailable Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if an email is already in use
        /// </summary>
        public async Task<bool> IsEmailAvailable(string email)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var exists = await context.Users.AnyAsync(u => u.Email == email);
                    return !exists;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IsEmailAvailable Error: {ex.Message}");
                return false;
            }
        }
    }
}
