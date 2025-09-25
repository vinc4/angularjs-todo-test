# Frontend - AngularJS Todo Application

A modern AngularJS 1.8.2 todo application with professional UI and service-based architecture.

## Features

- **CRUD Operations**: Create, Read, Update, Delete todos
- **Service Architecture**: Separated concerns with TodoService
- **Error Handling**: User-friendly error messages
- **Loading States**: Visual feedback during API calls
- **Responsive Design**: Bootstrap 5.3 with custom styling
- **Professional UI**: Modern gradient design with animations

## File Structure

```
frontend/
├── index.html              # Main HTML file
├── app.js                  # Module declaration
├── styles.css              # Custom CSS styling
├── controllers/
│   └── todoController.js   # Controller logic
└── services/
    └── todoService.js      # API service layer
```

## Running the Application

### Method 1: Python HTTP Server
```bash
cd frontend
python -m http.server 8000
```

### Method 2: Node.js HTTP Server
```bash
cd frontend
npx http-server -p 8000
```

### Method 3: PHP Built-in Server
```bash
cd frontend
php -S localhost:8000
```

### Method 4: Live Server (VS Code Extension)
- Install "Live Server" extension in VS Code
- Right-click on `index.html` → "Open with Live Server"

Then visit: **http://localhost:8000**

## Configuration

### API Integration

The app is currently configured to use JSONPlaceholder for demo data. To connect to your backend:

1. Open `services/todoService.js`
2. Update the `API_BASE_URL`:
   ```javascript
   var API_BASE_URL = 'http://localhost:5000/api';
   ```

### CORS Requirements

Your backend must enable CORS for the frontend domain:
```csharp

app.UseCors(policy => policy
    .WithOrigins("http://localhost:8000") 
    .AllowAnyMethod()
    .AllowAnyHeader());
```

## Architecture

### Service Layer (`services/todoService.js`)
- **getAllTodos()**: Fetch all todos
- **createTodo(text)**: Create new todo
- **updateTodo(id, data)**: Update existing todo
- **deleteTodo(id)**: Delete todo

### Controller Layer (`controllers/todoController.js`)
- **$scope.loadTodos()**: Load todos from API
- **$scope.addTodo()**: Add new todo
- **$scope.removeTodo(index)**: Remove todo
- **$scope.updateTodo(todo)**: Update todo completion
- **$scope.toggleAll()**: Toggle all todos
- **$scope.clearCompleted()**: Clear completed todos

## UI Components

- **Loading Spinner**: Shows during API calls
- **Error Messages**: Dismissible alerts for errors
- **Empty State**: Friendly message when no todos
- **Action Buttons**: Toggle all, clear completed
- **Statistics**: Todo counts display

## Dependencies

- **AngularJS 1.8.2**: Core framework
- **Bootstrap 5.3.0**: UI framework
- **Bootstrap Icons 1.10.0**: Icon library

## Responsive Design

- Mobile-friendly layout
- Responsive breakpoints
- Touch-friendly buttons
- Accessible form controls

## Testing

### Manual Testing Checklist
- [ ] Add new todo
- [ ] Mark todo as complete
- [ ] Edit todo text (if implemented)
- [ ] Delete todo
- [ ] Toggle all todos
- [ ] Clear completed todos
- [ ] Error handling (disconnect internet)
- [ ] Loading states visible

## Troubleshooting

### Common Issues

**1. CORS Errors**
- Ensure backend has CORS configured
- Check browser console for specific errors

**2. API Not Loading**
- Verify `API_BASE_URL` is correct
- Check network tab in browser dev tools

**3. Blank Page**
- Check browser console for JavaScript errors
- Ensure all script files are loading correctly

**4. HTTP Server Issues**
- Use `python -m http.server` instead of opening file directly
- Modern browsers require HTTP server for AngularJS
