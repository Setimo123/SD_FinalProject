# 🧑‍💻 UMECA Consultation Management System

A comprehensive **.NET 8 desktop application** for managing student–faculty consultations at the **University of Mindanao - College of Engineering Education**.

---

## 🎯 Project Overview

The **UMECA Consultation Management System** is a Windows Forms application designed to streamline the consultation scheduling process between students and faculty members.  
The system is intended **only for administrators or users with administrative privileges**, providing them exclusive access to manage consultations, bulletins, user data, and system configurations.

---

## 🌿 Repository Branches

This repository contains multiple branches for different components of the UMECA system:

| Branch | Description |
|--------|-------------|
| **master** | Desktop software (for admin) - Main application codebase |
| **UMECA_Database** | Database files and schema |
| **UMECA_Manuals** | Programmer's manual and documentation files |
| **UMECA_Mobile_Application** | Mobile Application (for students & faculty) |

To switch between branches:
```bash
git checkout <branch-name>
```

---

## ✨ Features

### 🧑‍💼 For Administrators
- 👤 Manage users (Students, Faculty, Admins)  
- 📚 Manage programs and departments   
- 📅 View and manage all consultation requests  
- 📢 Post and manage bulletin announcements  
- 📊 Access system-wide analytics 

---

## 🛠️ Technology Stack

| Component | Technology |
|------------|-------------|
| **Framework** | .NET 8 |
| **UI Framework** | Windows Forms with Guna2 UI Components |
| **Database** | SQL Server LocalDB |
| **ORM** | Entity Framework Core |
| **Architecture** | MVP (Model–View–Presenter) |
| **License** | Syncfusion Community License |

---

## 📋 Prerequisites

Before running the project, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- SQL Server LocalDB (included with Visual Studio)  
- Visual Studio 2022 or later (recommended)  
- Windows OS  

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/Setimo123/SD_FinalProject.git
cd SD_FinalProject
```

### 2. Database Setup

#### 🟢 Option A: Using PowerShell Script (Recommended)
```bash
.\scripts\QuickStart.ps1
```
Then select **Option 1** to reset and seed the database.

#### 🟡 Option B: Manual Setup
```bash
cd tools\MigrationRunner
dotnet run
```

### 3. Run the Application
```bash
cd src\Consultation.App
dotnet run
```

---

## 📁 Project Structure

```plaintext
SD_FinalProject/
├── src/
│   ├── Consultation.App/              # Windows Forms UI Layer
│   ├── Consultation.Domain/           # Domain Models & Entities
│   ├── Consultation.Infrastructure/   # Data Access Layer (EF Core)
│   ├── Consultation.Services/         # Business Logic Layer
│   └── Consultation.BackEndCRUD/      # CRUD Operations
│
├── tools/
│   ├── MigrationRunner/               # Database migration & seeding tool
│   └── TestLogin/                     # Login testing utility
│
├── scripts/
│   └── QuickStart.ps1                 # Quick start automation script
│
└── UMECA-Desktop-Software.sln                # Solution file
```

---

## 🗄️ Database Schema

### Core Entities
- **Users** – System users with role-based access (Student/Faculty/Admin)  
- **Student** – Profiles with program and enrollment information  
- **Faculty** – Faculty members with department assignments  
- **ConsultationRequest** – Consultation scheduling and tracking  
- **Department** – Academic departments  
- **Program** – Academic programs per department  
- **Course** – Course catalog  
- **EnrolledCourse** – Student course enrollments  
- **SchoolYear** – Academic year configuration  

---

## 🧪 Development Tools

### ▶️ Migration Runner
Creates and seeds the database with sample data:
```bash
cd tools\MigrationRunner
dotnet run
```

### 🔐 Test Login Utility
Verify authentication functionality:
```bash
cd tools\TestLogin
dotnet run
```

---

## 📦 NuGet Packages

Key dependencies:
- `Microsoft.EntityFrameworkCore.SqlServer`  
- `Microsoft.Extensions.Configuration`  
- `Guna.UI2.WinForms`  
- `Syncfusion.Windows.Forms`

---

## 🤝 Contributing

1. Fork the repository  
2. Create a feature branch  
   ```bash
   git checkout -b feature/AmazingFeature
   ```
3. Commit your changes  
   ```bash
   git commit -m "Add some AmazingFeature"
   ```
4. Push to the branch  
   ```bash
   git push origin feature/AmazingFeature
   ```
5. Open a Pull Request  

---

## 👨‍💻 Development Team

**University of Mindanao – College of Engineering Education**  
**BS Computer Engineering - CpE 223L (7599)**  
**Software Development Final Project**

---

## 📝 License

This project is developed for **academic purposes** at the **University of Mindanao**.

---

## 🐛 Known Issues

- 🪟 Application requires Windows OS (Windows Forms limitation)  
- 🗄️ SQL Server LocalDB must be installed and running  
- 🔑 Syncfusion license key required for full UI functionality  

---

## 💬 Support

For any issues, questions, or contributions, please contact the repository owners & contributors:  
**[Setimo123](https://github.com/Setimo123)**, **[jandreeeh](https://github.com/jandreeeh)**, or **[n2nyyy](https://github.com/n2nyyy)**.
 

---

## 🔄 Version History

- **v1.0.0 – Initial Release**
  - User authentication  
  - Consultation request management  
  - Bulletin board system  
  - User management dashboard  

---

> **Note:** This project was developed as part of the **Software Development** course at the **University of Mindanao**.
