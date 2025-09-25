# Todo Backend API

This folder will contain the .NET Core Web API backend for the Todo application.

## Planned Structure:
```
backend/
├── TodoApi/
│   ├── Controllers/
│   │   └── TodoController.cs
│   ├── Models/
│   │   └── Todo.cs
│   ├── Data/
│   │   └── TodoContext.cs
│   ├── Program.cs
│   └── TodoApi.csproj
├── TodoApi.sln
└── README.md (this file)
```

## Requirements:
- Latest .NET Core version
- Entity Framework Core
- SQL Database (SQL Server, SQLite, or PostgreSQL)
- CORS enabled for frontend integration

## API Endpoints to Implement:
- `GET /api/todos` - Get all todos
- `GET /api/todos/{id}` - Get todo by ID
- `POST /api/todos` - Create new todo
- `PUT /api/todos/{id}` - Update todo
- `DELETE /api/todos/{id}` - Delete todo

## Next Steps:
1. Create new .NET Core Web API project
2. Install Entity Framework Core packages
3. Configure database connection
4. Create Todo model and DbContext
5. Implement TodoController with CRUD operations
6. Add seed data
7. Configure CORS for frontend
8. Test API endpoints