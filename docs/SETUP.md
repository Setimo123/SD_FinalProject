# UMECA Bulletin Board - Setup Guide

This guide will help you set up and run the UMECA Bulletin Board System on your local machine.

## Table of Contents
1. [Prerequisites](#prerequisites)
2. [Installation Steps](#installation-steps)
3. [Database Setup](#database-setup)
4. [Running the Application](#running-the-application)
5. [Troubleshooting](#troubleshooting)

## Prerequisites

Before you begin, ensure you have the following installed on your system:

### Required Software
- **Node.js** (v20 or higher)
  - Download from: https://nodejs.org/
  - Verify installation: `node --version`
  
- **npm** (comes with Node.js)
  - Verify installation: `npm --version`
  
- **SQL Server LocalDB** or SQL Server Express
  - Download from: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
  - LocalDB is included with Visual Studio
  
- **.NET SDK** (for C# API server)
  - Download from: https://dotnet.microsoft.com/download
  - Verify installation: `dotnet --version`

### Optional Tools
- **Git** (for version control)
- **Visual Studio Code** (recommended IDE)
- **SQL Server Management Studio** (for database management)

## Installation Steps

### 1. Clone or Extract the Project

```bash
# If using Git
git clone <repository-url>
cd antoni-main

# If using ZIP file
# Extract the ZIP and navigate to the folder
cd antoni-main
```

### 2. Install Node.js Dependencies

```bash
npm install
```

This will install all required packages listed in `package.json`:
- Next.js
- React
- Tailwind CSS
- Embla Carousel
- Day.js
- And more...

### 3. Configure Environment Variables

Create a `.env.local` file in the root directory:

```bash
# Copy the example file
copy .env.example .env.local
```

Edit `.env.local` with your configuration:

```env
NEXT_PUBLIC_BASE_URL=http://localhost:3000
CS_API_URL=http://localhost:5000/api/bulletin
```

## Database Setup

### 1. Verify SQL Server LocalDB Installation

Open Command Prompt or PowerShell and run:

```bash
sqllocaldb info
```

You should see a list of LocalDB instances. If not, install SQL Server LocalDB.

### 2. Create the Database

You can create the database using SQL Server Management Studio or via command line:

#### Using SQL Command
```sql
CREATE DATABASE ConsultationDatabase;
GO

USE ConsultationDatabase;
GO

CREATE TABLE Bulletins (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(100),
    Content NVARCHAR(MAX) NOT NULL,
    Status INT DEFAULT 1,
    DatePublished DATETIME NOT NULL DEFAULT GETDATE(),
    FileCount INT DEFAULT 0,
    IsArchived BIT DEFAULT 0
);
GO
```

### 3. Insert Sample Data (Optional)

```sql
INSERT INTO Bulletins (Title, Author, Content, Status, DatePublished)
VALUES 
('Welcome to UMECA', 'Admin', 'Welcome to the UMECA Bulletin Board System!', 1, GETDATE()),
('System Announcement', 'Admin', 'The system is now live and ready for use.', 1, GETDATE());
GO
```

### 4. Verify Database Connection

Check the connection settings in `src/lib/db.ts`:

```typescript
const config = {
  server: 'localhost',
  database: 'ConsultationDatabase',
  options: {
    instanceName: 'MSSQLLocalDB',
    // ... other options
  }
};
```

## Running the Application

### Step 1: Start the C# API Server

The C# API server connects to SQL Server LocalDB and exposes REST endpoints.

```bash
# Navigate to the project root if not already there
cd antoni-main

# Run the C# API server
dotnet run --project BulletinApiServer.cs
```

The API should start on `http://localhost:5000`

**Expected Output:**
```
✅ C# API Server running on http://localhost:5000
✅ Connected to SQL Server LocalDB
```

### Step 2: Start the Next.js Development Server

Open a new terminal window/tab:

```bash
# Navigate to project root
cd antoni-main

# Start development server
npm run dev
```

The application should start on `http://localhost:3000`

**Expected Output:**
```
✓ Ready in 2.5s
○ Compiling / ...
✓ Compiled / in 1.2s
```

### Step 3: Access the Application

Open your web browser and navigate to:
```
http://localhost:3000
```

You should see the UMECA Bulletin Board with:
- Logo and header at the top
- Real-time clock and date
- Auto-scrolling carousel with bulletins

## Production Build

To create an optimized production build:

```bash
# Build the application
npm run build

# Start production server
npm start
```

The production build will be available at `http://localhost:3000`

## Troubleshooting

### Issue: "Cannot connect to database"

**Solutions:**
1. Verify SQL Server LocalDB is running:
   ```bash
   sqllocaldb start MSSQLLocalDB
   ```
2. Check database name in `src/lib/db.ts` matches your LocalDB instance
3. Ensure Windows authentication is enabled
4. Try connecting with SQL Server Management Studio to verify credentials

### Issue: "C# API not responding"

**Solutions:**
1. Ensure .NET SDK is installed: `dotnet --version`
2. Check if port 5000 is already in use
3. Verify `BulletinApiServer.cs` has correct database connection string
4. Check firewall settings

### Issue: "Carousel not auto-playing"

**Solutions:**
1. Open browser console (F12) and check for errors
2. Verify bulletins are being fetched: Check Network tab
3. Ensure Embla Carousel dependencies are installed:
   ```bash
   npm install embla-carousel-autoplay embla-carousel-react
   ```

### Issue: "Module not found" errors

**Solutions:**
1. Delete node_modules and reinstall:
   ```bash
   rm -rf node_modules
   npm install
   ```
2. Clear Next.js cache:
   ```bash
   rm -rf .next
   npm run dev
   ```

### Issue: "Port already in use"

**Solutions:**
1. For Next.js (port 3000):
   ```bash
   npm run dev -- -p 3001
   ```
2. For C# API (port 5000), edit the port in `BulletinApiServer.cs`

## Additional Configuration

### Changing the Logo
Replace `public/logo.png` with your institution's logo (recommended size: 400x400px)

### Changing the Background Gradient
Edit `src/app/layout.tsx` and `src/app/globals.css`

### Adjusting Carousel Speed
Edit `src/app/_components/bulletin.tsx`:
```typescript
delay: 5000, // Change to desired milliseconds
```

## Getting Help

If you encounter issues not covered in this guide:
1. Check the main README.md for additional information
2. Review the code comments in each file
3. Consult your course instructor
4. Check the browser console and terminal for error messages

---

**Happy coding! 🚀**
