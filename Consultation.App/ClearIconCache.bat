@echo off
echo Clearing Windows Icon Cache...
echo.
echo Please close all running instances of Consultation.App first!
echo Press any key to continue or CTRL+C to cancel...
pause > nul

echo.
echo Stopping Windows Explorer...
taskkill /f /im explorer.exe

echo.
echo Deleting icon cache files...
del /f /s /q /a "%localappdata%\IconCache.db" 2>nul
del /f /s /q /a "%localappdata%\Microsoft\Windows\Explorer\iconcache*.db" 2>nul

echo.
echo Restarting Windows Explorer...
start explorer.exe

echo.
echo Icon cache cleared successfully!
echo Please run your application now to see the new icon.
echo.
pause
