# Consultation App - Quick Start Script
# This script sets up and runs the Consultation App with local database

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Consultation App - Quick Start" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Check if LocalDB is running
Write-Host "Checking LocalDB status..." -ForegroundColor Yellow
try {
    $localDbInfo = sqllocaldb info MSSQLLocalDB 2>&1
    if ($LASTEXITCODE -eq 0) {
      Write-Host "✓ LocalDB is available" -ForegroundColor Green
    } else {
        Write-Host "! LocalDB not found. Starting..." -ForegroundColor Yellow
        sqllocaldb start MSSQLLocalDB
    }
} catch {
    Write-Host "✗ LocalDB check failed" -ForegroundColor Red
}

Write-Host ""

# Ask user what they want to do
Write-Host "What would you like to do?" -ForegroundColor Cyan
Write-Host "1. Reset Database (Fresh start - recreate and seed data)"
Write-Host "2. Test Login"
Write-Host "3. Run Consultation App"
Write-Host "4. View Database Info"
Write-Host "5. Exit"
Write-Host ""

$choice = Read-Host "Enter choice (1-5)"

switch ($choice) {
    "1" {
        Write-Host ""
    Write-Host "Resetting database..." -ForegroundColor Yellow
   Push-Location "tools\MigrationRunner"
    dotnet run
     Pop-Location
    }
    "2" {
 Write-Host ""
        Write-Host "Testing login..." -ForegroundColor Yellow
 Push-Location "tools\TestLogin"
   dotnet run
        Pop-Location
    }
 "3" {
   Write-Host ""
  Write-Host "Starting Consultation App..." -ForegroundColor Yellow
        Write-Host "Login with:" -ForegroundColor Cyan
        Write-Host "  Email: jgallenero@umindanao.edu.ph" -ForegroundColor White
        Write-Host "  Password: MyAdmin123!" -ForegroundColor White
    Write-Host ""
        Push-Location "src\Consultation.App"
    dotnet run
     Pop-Location
    }
    "4" {
 Write-Host ""
        Write-Host "Database Information:" -ForegroundColor Cyan
    Write-Host "  Server: (localdb)\MSSQLLocalDB" -ForegroundColor White
        Write-Host "  Database: ConsultationDatabase" -ForegroundColor White
        Write-Host ""
        Write-Host "Checking user count..." -ForegroundColor Yellow
        sqlcmd -S "(localdb)\MSSQLLocalDB" -d ConsultationDatabase -Q "SELECT UserType, COUNT(*) as Count FROM AspNetUsers GROUP BY UserType ORDER BY UserType" -W
        Write-Host ""
        Write-Host "Admin users:" -ForegroundColor Yellow
 sqlcmd -S "(localdb)\MSSQLLocalDB" -d ConsultationDatabase -Q "SELECT Email, UserName, UMID FROM AspNetUsers WHERE UserType = 3" -W
    }
    "5" {
        Write-Host ""
        Write-Host "Goodbye!" -ForegroundColor Cyan
        exit
    }
    default {
        Write-Host ""
        Write-Host "Invalid choice. Exiting." -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
