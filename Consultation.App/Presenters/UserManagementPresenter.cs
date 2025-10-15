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
        private string _currentUserType = "Student"; // Track which user type is currently displayed
        private string _currentSearchTerm = ""; // Track the current search term

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
            _currentUserType = "Student";
            _currentSearchTerm = ""; // Reset search when switching tabs
            await LoadStudentCards();
        }

        private async void FacultyManagementEvent(object? sender, EventArgs e)
        {
            // Logic for handling faculty management event
            _currentUserType = "Faculty";
            _currentSearchTerm = ""; // Reset search when switching tabs
            await LoadFacultyCards();
        }

        private async void AdminManagementEvent(object? sender, EventArgs e)
        {
            // Logic for handling admin management event
            _currentUserType = "Admin";
            _currentSearchTerm = ""; // Reset search when switching tabs
            await LoadAdminCards();
        }

        /// <summary>
        /// Performs search based on the current user type displayed
        /// </summary>
        public async Task SearchUsers(string searchTerm)
        {
            try
            {
                _currentSearchTerm = searchTerm;

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    // If search is empty, reload all users for current type
                    switch (_currentUserType)
                    {
                        case "Student":
                            await LoadStudentCards();
                            break;
                        case "Faculty":
                            await LoadFacultyCards();
                            break;
                        case "Admin":
                            await LoadAdminCards();
                            break;
                    }
                    return;
                }

                // Perform search based on current user type
                switch (_currentUserType)
                {
                    case "Student":
                        await SearchStudentCards(searchTerm);
                        break;
                    case "Faculty":
                        await SearchFacultyCards(searchTerm);
                        break;
                    case "Admin":
                        await SearchAdminCards(searchTerm);
                        break;
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error searching users: {ex.Message}");
            }
        }

        private async Task SearchStudentCards(string searchTerm)
        {
            try
            {
                _userManagementView.ClearUserCards();

                var students = await _studentRepository.SearchStudents(searchTerm);

                await AddCardsInBatchesAsync(students, (student) =>
                {
                    _userManagementView.AddUserCard(
                        student.StudentName,
                        student.StudentUMID,
                        student.Email
                    );
                });

                if (students.Count == 0)
                {
                    _userManagementView.Message($"No students found matching '{searchTerm}'.");
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error searching students: {ex.Message}");
            }
        }

        private async Task SearchFacultyCards(string searchTerm)
        {
            try
            {
                _userManagementView.ClearUserCards();

                var facultyList = await _facultyRepository.SearchFaculty(searchTerm);

                await AddCardsInBatchesAsync(facultyList, (faculty) =>
                {
                    _userManagementView.AddUserCard(
                        faculty.FacultyName,
                        faculty.FacultyUMID,
                        faculty.FacultyEmail
                    );
                });

                if (facultyList.Count == 0)
                {
                    _userManagementView.Message($"No faculty members found matching '{searchTerm}'.");
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error searching faculty: {ex.Message}");
            }
        }

        private async Task SearchAdminCards(string searchTerm)
        {
            try
            {
                _userManagementView.ClearUserCards();

                var admins = await _adminRepository.SearchAdmin(searchTerm);

                await AddCardsInBatchesAsync(admins, (admin) =>
                {
                    _userManagementView.AddUserCard(
                        admin.AdminName,
                        admin.Users?.UMID ?? "N/A",
                        admin.Users?.Email ?? "N/A"
                    );
                });

                if (admins.Count == 0)
                {
                    _userManagementView.Message($"No administrators found matching '{searchTerm}'.");
                }
            }
            catch (Exception ex)
            {
                _userManagementView.Message($"Error searching administrators: {ex.Message}");
            }
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

                // Show loading indicator (optional)
                // _userManagementView.Message("Loading students...");

                // Fetch all students from the database
                var students = await _studentRepository.GetAllStudents();

                // Add cards in batches for smooth rendering
                await AddCardsInBatchesAsync(students, (student) =>
                {
                    _userManagementView.AddUserCard(
                        student.StudentName,
                        student.StudentUMID,
                        student.Email
                    );
                });

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

                // Add cards in batches for smooth rendering
                await AddCardsInBatchesAsync(facultyList, (faculty) =>
                {
                    _userManagementView.AddUserCard(
                        faculty.FacultyName,
                        faculty.FacultyUMID,
                        faculty.FacultyEmail
                    );
                });

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

                // Add cards in batches for smooth rendering
                await AddCardsInBatchesAsync(admins, (admin) =>
                {
                    _userManagementView.AddUserCard(
                        admin.AdminName,
                        admin.Users?.UMID ?? "N/A",
                        admin.Users?.Email ?? "N/A"
                    );
                });

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

        /// <summary>
        /// Adds cards in batches to prevent UI freezing and improve performance
        /// </summary>
        /// <typeparam name="T">The type of items to process</typeparam>
        /// <param name="items">List of items to add</param>
        /// <param name="addCardAction">Action to add each card</param>
        /// <param name="batchSize">Number of items to process per batch (default: 10)</param>
        private async Task AddCardsInBatchesAsync<T>(List<T> items, Action<T> addCardAction, int batchSize = 10)
        {
            if (items == null || items.Count == 0)
                return;

            for (int i = 0; i < items.Count; i += batchSize)
            {
                // Process a batch of items
                int endIndex = Math.Min(i + batchSize, items.Count);
                
                for (int j = i; j < endIndex; j++)
                {
                    addCardAction(items[j]);
                }

                // Allow UI to refresh after each batch
                // This prevents the UI from freezing during large data loads
                await Task.Delay(1);
                
                // Force the UI to process pending messages
                Application.DoEvents();
            }
        }
    }
}
