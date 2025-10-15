using Consultation.App.Views.Controls.UserManagement;

namespace Consultation.App.Views.IViews
{
    public interface IUserManagementView : IChildView
    {
        event EventHandler StudentManagementEvent;
        event EventHandler FacultyManagementEvent;
        event EventHandler AdminManagementEvent;

        void AddUserCard(string name, string id, string email);
        void ClearUserCards();
        void Message(string message);
        void UpdateTotalStudents(int count);
        void UpdateTotalFaculty(int count);
        void UpdateTotalAdmin(int count);
    }
}
