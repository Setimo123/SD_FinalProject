using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.App.Views;
using Consultation.App.Views.IViews;
using Consultation.Repository.Repository.IRepository;
using Consultation.Infrastructure.Data;

namespace Consultation.App.Presenters
{
    public class UserManagementPresenter
    {
        private readonly IUserManagementView _userManagementView;
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IAdminRepository _adminRepository;

        public UserManagementPresenter(IUserManagementView userManagementView)
        {
            _userManagementView = userManagementView;
            _userManagementView.StudentManagementEvent += StudentManagementEvent;
            _userManagementView.FacultyManagementEvent += FacultyManagementEvent;
            _userManagementView.AdminManagementEvent += AdminManagementEvent;

            // Initialize repositories with AppDbContext
            var context = new AppDbContext();
            _studentRepository = new Consultation.Repository.Repository.StudentRepository(context);
            _facultyRepository = new Consultation.Repository.Repository.FacultyRepository(context);
            _adminRepository = new Consultation.Repository.Repository.AdminRepository(context);

            // Load total counts on initialization
            LoadTotalCounts();
        }

        private async void LoadTotalCounts()
        {
            try
            {
                var studentCount = await _studentRepository.GetTotalStudentsCount();
                var facultyCount = await _facultyRepository.GetTotalFacultyCount();
                var adminCount = await _adminRepository.GetTotalAdminCount();

                _userManagementView.UpdateTotalStudents(studentCount);
                _userManagementView.UpdateTotalFaculty(facultyCount);
                _userManagementView.UpdateTotalAdmin(adminCount);
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error loading user counts: {ex.Message}");
            }
        }

        private async void StudentManagementEvent(object? sender, EventArgs e)
        {
            // Logic for handling student management event
            await LoadStudentCards();
        }

        private async void FacultyManagementEvent(object? sender, EventArgs e)
        {
            // Logic for handling faculty management event
            await LoadFacultyCards();
        }

        private async void AdminManagementEvent(object? sender, EventArgs e)
        {
            // Logic for handling admin management event
            await LoadAdminCards();
        }

        public void LoadTestCards(string name, int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                _userManagementView.AddUserCard(String.Concat(name, i), $"ID{i}", $"email{i}@test.com");
            }
        }

        private async Task LoadStudentCards()
        {
            try
            {
                // Clear existing cards
                _userManagementView.ClearUserCards();

                // Fetch all students from the database
                var students = await _studentRepository.GetAllStudents();

                // Add a card for each student
                foreach (var student in students)
                {
                    _userManagementView.AddUserCard(
                        student.StudentName,
                        student.StudentUMID,
                        student.Email
                    );
                }

                // Update total count
                _userManagementView.UpdateTotalStudents(students.Count);

                // Show message if no students found
                if (students.Count == 0)
                {
                    _userManagementView.Message("No students found in the database.");
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error loading students: {ex.Message}");
            }
        }

        private async Task LoadFacultyCards()
        {
            try
            {
                // Clear existing cards
                _userManagementView.ClearUserCards();

                // Fetch all faculty from the database
                var facultyList = await _facultyRepository.GetAllFaculty();

                // Add a card for each faculty
                foreach (var faculty in facultyList)
                {
                    _userManagementView.AddUserCard(
                        faculty.FacultyName,
                        faculty.FacultyUMID,
                        faculty.FacultyEmail
                    );
                }

                // Update total count
                _userManagementView.UpdateTotalFaculty(facultyList.Count);

                // Show message if no faculty found
                if (facultyList.Count == 0)
                {
                    _userManagementView.Message("No faculty members found in the database.");
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error loading faculty: {ex.Message}");
            }
        }

        private async Task LoadAdminCards()
        {
            try
            {
                // Clear existing cards
                _userManagementView.ClearUserCards();

                // Fetch all admins from the database
                var admins = await _adminRepository.GetAllAdmin();

                // Add a card for each admin
                foreach (var admin in admins)
                {
                    // For admin, we use the Users.Email since Admin doesn't have a direct email field
                    _userManagementView.AddUserCard(
                        admin.AdminName,
                        admin.Users?.UMID ?? "N/A",
                        admin.Users?.Email ?? "N/A"
                    );
                }

                // Update total count
                _userManagementView.UpdateTotalAdmin(admins.Count);

                // Show message if no admins found
                if (admins.Count == 0)
                {
                    _userManagementView.Message("No administrators found in the database.");
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error loading administrators: {ex.Message}");
            }
        }
    }
}
