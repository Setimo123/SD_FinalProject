# UserView Control - Usage Guide

## Overview
The `UserView` control displays detailed information about users (Students, Faculty, or Administrators) registered in the database.

## Components Mapping

The following UI components display user information from the database:

| Component | Property | Description |
|-----------|----------|-------------|
| `USname` | Label | Displays the complete name of the user |
| `gradientUID` | GradientLabel | Displays the complete UMID (University ID) of the user |
| `gradientEM` | GradientLabel | Displays the complete email address of the user |
| `gradientRLE` | GradientLabel | Displays the UserType (Student, Faculty, or Administrator) |
| `gradientCTC` | GradientLabel | Displays the contact number (optional) |
| `gradientDEPT` | GradientLabel | Displays the department name (optional) |

## Methods

### SetUserInformation
Sets the primary user information to be displayed in the UserView.

```csharp
public void SetUserInformation(string name, string umid, string email, UserType userType)
```

**Parameters:**
- `name` - Complete name of the user
- `umid` - UMID of the user
- `email` - Email address of the user
- `userType` - User type enum (Student, Faculty, or Admin)

**Example:**
```csharp
userView.SetUserInformation(
    "John Doe", 
    "550200", 
    "j.doe@umindanao.edu.ph", 
    UserType.Student
);
```

### SetAdditionalInformation
Sets additional information like contact and department.

```csharp
public void SetAdditionalInformation(string contact, string department)
```

**Parameters:**
- `contact` - Contact number
- `department` - Department name

**Example:**
```csharp
userView.SetAdditionalInformation(
    "+639123456789", 
    "College of Engineering Education"
);
```

## Usage Examples

### Example 1: Basic Usage
```csharp
// Create UserView instance
UserView userView = new UserView();

// Set user information
userView.SetUserInformation(
    "Rene Cedric Setimo", 
    "550200", 
    "r.setimo.550200@umindanao.edu.ph", 
    UserType.Student
);

// Set additional information
userView.SetAdditionalInformation(
    "+639123456789", 
    "College of Engineering Education"
);

// Display in a form
Form viewForm = new Form();
viewForm.Controls.Add(userView);
viewForm.ShowDialog();
```

### Example 2: Loading from Database
```csharp
// Loading user data from the database
using (var context = new AppDbContext())
{
    var user = await context.Users.FirstOrDefaultAsync(u => u.UMID == "550200");
    
    if (user != null)
    {
        var student = await context.Students
            .Include(s => s.Program)
            .ThenInclude(p => p.Department)
            .FirstOrDefaultAsync(s => s.StudentUMID == user.UMID);
        
        if (student != null)
        {
            userView.SetUserInformation(
                student.StudentName,
                student.StudentUMID,
                student.Email,
                user.UserType
            );
            
            userView.SetAdditionalInformation(
                "N/A",
                student.Program?.Department?.Description ?? "N/A"
            );
        }
    }
}
```

### Example 3: Integration with UserCard
The `UserCard` control automatically loads and displays user information when the "View" action is clicked:

```csharp
// In UserCard.cs - viewTSMI_Click method
private void viewTSMI_Click(object sender, EventArgs e)
{
    Form viewForm = new Form
    {
        Text = "User Details",
        Size = new Size(970, 600),
        StartPosition = FormStartPosition.CenterScreen,
        FormBorderStyle = FormBorderStyle.None
    };

    UserView userView = new UserView();
    userView.Dock = DockStyle.Fill;
    
    // Load user data from database
    LoadUserDataToView(userView);
    
    viewForm.Controls.Add(userView);
    viewForm.ShowDialog();
}
```

## UserType Enum Values

The `UserType` enum has the following values:

| Value | Display Text |
|-------|--------------|
| `UserType.Student` | "Student" |
| `UserType.Faculty` | "Faculty" |
| `UserType.Admin` | "Administrator" |

## Database Structure

The UserView pulls information from the following database tables:

### Users Table
- `UMID` - University ID
- `Email` - User email address
- `UserType` - Enum indicating user type (Student/Faculty/Admin)

### Student Table
- `StudentName` - Full name
- `StudentUMID` - Links to Users.UMID
- `Email` - Student email
- `ProgramID` - Links to Program table

### Faculty Table
- `FacultyName` - Full name
- `FacultyUMID` - Links to Users.UMID
- `FacultyEmail` - Faculty email
- `ProgramID` - Links to Program table

### Admin Table
- `AdminName` - Full name
- `UsersID` - Links to Users.Id

### Program & Department Tables
- Programs are linked to Departments
- Used to display department information

## Notes

1. The `UserView` control automatically handles the display of user information
2. If user data is not found in the database, fallback values ("N/A") are displayed
3. The contact number field is currently set to "N/A" as it's not in the current database schema
4. Department information is loaded from the related Program and Department tables
5. The control uses async/await pattern for database operations

## Error Handling

The control includes error handling for database operations:

```csharp
try
{
    // Database operations
}
catch (Exception ex)
{
    MessageBox.Show($"Error loading user data: {ex.Message}");
    // Fallback to default values
}
```

## Future Enhancements

Consider adding these fields to the database schema for complete functionality:
- Contact number field in Student/Faculty tables
- Additional profile information
- Profile picture support
