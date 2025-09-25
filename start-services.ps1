# Start Services Script for AngularJS Todo App
# This script starts both the backend API and provides instructions for the frontend

Write-Host "Starting AngularJS Todo App Services" -ForegroundColor Green
Write-Host "====================================" -ForegroundColor Green

# Start the backend API
Write-Host "`nStarting Backend API..." -ForegroundColor Yellow
Write-Host "API will be available at: http://localhost:5020" -ForegroundColor Cyan
Write-Host "Swagger docs at: http://localhost:5020/swagger" -ForegroundColor Cyan

Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd 'backend\TodoApi'; dotnet run"

# Wait a moment for the API to start
Start-Sleep -Seconds 2

# Start the frontend server
Write-Host "`nStarting Frontend Server..." -ForegroundColor Yellow
Write-Host "Frontend will be available at: http://localhost:8080" -ForegroundColor Cyan

Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd 'frontend'; python -m http.server 8080; Read-Host 'Press Enter to close'"

Write-Host "`nAlternative Frontend Options:" -ForegroundColor Yellow
Write-Host "   - Node.js: cd frontend; npx http-server -p 8080" -ForegroundColor Cyan
Write-Host "   - VS Code Live Server extension (right-click index.html)" -ForegroundColor Cyan

Write-Host "`nBackend API is starting up!" -ForegroundColor Green
Write-Host "Services initialized successfully. Your application is ready at http://localhost:8080" -ForegroundColor Green