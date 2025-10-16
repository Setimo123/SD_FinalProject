# User Delete Quick Reference

## How to Delete a User

### Method 1: From User Details View (UserView)
1. Open a user's details by clicking "View" on their user card
2. In the "Quick Actions" panel on the right, click the **"Delete"** button
3. A confirmation dialog will appear asking if you're sure
4. Click "Yes" to confirm deletion or "No" to cancel
5. If confirmed, the user and all related data will be permanently deleted
6. The UserView form will automatically close upon successful deletion

### Method 2: From User Card Context Menu (UserCard)
1. Find the user card you want to delete
2. Click the **"..."** (more) button on the right side of the card
3. Select **"Delete user"** from the context menu
4. A confirmation dialog will appear asking if you're sure
5. Click "Yes" to confirm deletion or "No" to cancel
6. If confirmed, the user and all related data will be permanently deleted
7. The user card will be removed from the list upon successful deletion

## What Gets Deleted

When you delete a user, the following data is permanently removed from the database:

### For All Users:
- ? User account (login credentials)
- ? Action logs (user activity history)

### For Students:
- ? Student profile information
- ? All enrolled courses
- ? All consultation requests

### For Faculty:
- ? Faculty profile information
- ? All consultation requests assigned to them

### For Admins:
- ? Administrator profile information

## Important Warnings

?? **Permanent Action:** Deletion is permanent and cannot be undone!

?? **Data Loss:** All related records will be deleted (enrollments, consultations, etc.)

?? **No Recovery:** There is no way to restore a deleted user

## Safety Features

?? **Confirmation Required:** You must confirm deletion before it proceeds

?? **Default to Cancel:** The "No" button is selected by default to prevent accidents

?? **Detailed Warning:** The confirmation dialog lists exactly what will be deleted

?? **Transaction Safety:** If any part of the deletion fails, all changes are rolled back

## Error Messages

### Success:
"User has been permanently deleted!"

### Failure:
"Failed to delete the user. Please try again."

### Exception:
"An error occurred while deleting the user: [error details]"

## Code Reference

### Service Method:
```csharp
await UserService.Instance.DeleteUser(umid);
```

### Confirmation Dialog:
```csharp
var result = MessageBox.Show(
    "Are you sure you want to permanently delete the user...?",
    "Delete User",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button2);
```

## Troubleshooting

**Q: The delete button doesn't work**
- A: Make sure the user has a valid UMID stored in `_currentUMID`

**Q: Deletion fails with an error**
- A: Check the console logs for detailed error information
- Verify database connectivity
- Ensure no other processes are holding locks on the user record

**Q: Can I undo a deletion?**
- A: No, deletions are permanent. There is no undo functionality currently.

**Q: What happens if the deletion partially fails?**
- A: The transaction will be rolled back, and no changes will be made to the database.
