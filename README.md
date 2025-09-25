# AngularJS Todo Application with .NET Core Backend

A full-stack todo application built with AngularJS frontend and .NET Core 9.0 backend API.

## 🚀 Features

- **Frontend**: AngularJS 1.8.2 with Bootstrap 5.3 styling
- **Backend**: .NET Core 9.0 Web API with Entity Framework Core
- **Database**: SQLite for data persistence
- **API Documentation**: Swagger/OpenAPI integration
- **Architecture**: Clean service layer pattern with dependency injection
- **CORS**: Configured for cross-origin requests

## 📋 API Endpoints

The backend provides full CRUD operations:

- `GET /api/todos` - Get all todos
- `GET /api/todos/{id}` - Get specific todo
- `POST /api/todos` - Create new todo
- `PUT /api/todos/{id}` - Update existing todo
- `DELETE /api/todos/{id}` - Delete todo

## 🛠️ Prerequisites

- .NET 9.0 SDK or later
- Python 3.x (for frontend development server)
- Git

## 🏃‍♂️ Running the Application

### Backend (.NET Core API)

1. Navigate to the backend directory:
   ```bash
   cd backend/TodoApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the API:
   ```bash
   dotnet run
   ```

   The API will be available at: `http://localhost:5020`
   Swagger documentation: `http://localhost:5020/swagger`

### Frontend (AngularJS)

1. From the project root directory:
   ```bash
   python -m http.server 8000
   ```

2. Open your browser and navigate to: `http://localhost:8000`

## 🗄️ Database

The application uses SQLite with Entity Framework Core. The database will be automatically created with seed data when you first run the backend.

### Seed Data

The application comes with 5 default todos:
- Learn AngularJS
- Build a todo app (completed)
- Create .NET Core API
- Connect frontend to backend
- Deploy the application

## 🏗️ Project Structure

```
angularjs-todo-test-main/
├── frontend/
│   ├── controllers/
│   │   └── todoController.js
│   └── services/
│       └── todoService.js
├── backend/
│   └── TodoApi/
│       ├── Controllers/
│       │   └── TodosController.cs
│       ├── Services/
│       │   ├── ITodoService.cs
│       │   ├── TodoService.cs
│       │   └── DatabaseSeedService.cs
│       ├── DTOs/
│       │   ├── CreateTodoRequest.cs
│       │   ├── UpdateTodoRequest.cs
│       │   └── TodoResponse.cs
│       ├── Models/
│       │   └── Todo.cs
│       ├── Data/
│       │   ├── TodoContext.cs
│       │   └── Seeds/
│       │       └── sample_todos.sql
│       └── Program.cs
├── app.js
├── index.html
├── styles.css
├── README.md
└── AngularJsTodoApp.sln
```

## Features

### Frontend (AngularJS)
- Add new todos
- Mark todos as complete/incomplete
- Delete completed todos
- Filter todos (All, Active, Completed)
- Real-time updates with backend API
- Loading states and error handling
- Responsive Bootstrap UI

### Backend (.NET Core Web API)
- RESTful API endpoints
- Entity Framework Core with SQLite
- CORS configuration for frontend
- Swagger/OpenAPI documentation
- Automatic database seeding with sample data
- Full CRUD operations

## Technologies Used

### Frontend
- AngularJS 1.8.2
- Bootstrap 5.3
- HTML5/CSS3

### Backend
- .NET Core 9.0
- Entity Framework Core 9.0
- SQLite Database
- Swagger/OpenAPI

## Setup and Running

### Prerequisites
- .NET 9.0 SDK
- Web browser
- Simple HTTP server (for frontend)

### Backend Setup
1. Navigate to the backend directory:
   ```powershell
   cd backend\TodoApi
   ```

2. Restore dependencies and run:
   ```powershell
   dotnet restore
   dotnet run
   ```
   
   **API Endpoints:**
   - **Command Line**: `http://localhost:5020` (Swagger: `http://localhost:5020/swagger`)
   - **Visual Studio**: `https://localhost:7184` (Swagger: `https://localhost:7184/swagger`)
   
   > **Note**: Both HTTP and HTTPS endpoints are supported with CORS configured for development.

### Frontend Setup
1. **Automated Setup (Recommended)**:
   ```powershell
   .\start-services.ps1
   ```
   This automatically starts both backend and frontend servers.

2. **Manual Setup**:
   Navigate to the frontend directory and start a server:
   ```powershell
   cd frontend
   python -m http.server 8080
   ```
   
   Or use VS Code Live Server extension.
   
   The frontend will be available at: `http://localhost:8080`

### Building from Solution Root
```powershell
# Build entire solution (stop API first)
dotnet build AngularJsTodoApp.sln

# Run from solution root
dotnet run --project backend\TodoApi\TodoApi.csproj
```

## API Endpoints

- `GET /api/todos` - Get all todos
- `GET /api/todos/{id}` - Get specific todo
- `POST /api/todos` - Create new todo
- `PUT /api/todos/{id}` - Update todo
- `DELETE /api/todos/{id}` - Delete todo

## Database

The application uses SQLite with Entity Framework Core. The database file (`todos.db`) is created automatically in the backend directory. Sample data is seeded on first run.

## Development Notes

- The frontend service (`todoService.js`) is configured to connect to the backend API
- CORS is configured to allow frontend access from any origin during development
- The solution file (`AngularJsTodoApp.sln`) allows building and managing the entire project from Visual Studio or command line
- Database migrations are applied automatically on startup
