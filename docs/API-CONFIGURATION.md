# API Configuration Guide

## Backend Endpoints

When you run the TodoApi project, it will be available on different ports depending on how you start it:

### Command Line (`dotnet run`)
- **HTTP**: `http://localhost:5020`
- **Swagger**: `http://localhost:5020/swagger`

### Visual Studio (F5 Debug)
- **HTTP**: `http://localhost:5020` 
- **HTTPS**: `https://localhost:7184`
- **Swagger**: `https://localhost:7184/swagger` or `http://localhost:5020/swagger`

## CORS Configuration

The API is configured for **development mode** with:
- **Allow Any Origin** (`*`) - Accepts requests from any domain/port
- **Allow Any Method** - Supports all HTTP methods (GET, POST, PUT, DELETE, etc.)
- **Allow Any Header** - Accepts any request headers

> **Note**: This permissive CORS policy is ideal for development but should be restricted in production.

## Frontend Configuration

The frontend (`frontend/services/todoService.js`) is currently configured to use:
```javascript
var API_BASE_URL = 'http://localhost:5020/api';
```

### To use HTTPS endpoint (when running from Visual Studio):
Change the API_BASE_URL in `frontend/services/todoService.js`:
```javascript
var API_BASE_URL = 'https://localhost:7184/api';
```

## Development Notes

- **HTTPS redirection is disabled** in development mode to prevent CORS issues
- **Both HTTP and HTTPS** endpoints work simultaneously when running from Visual Studio
- **Swagger UI** works on both endpoints
- **Frontend** can connect to either endpoint depending on configuration

## Troubleshooting CORS Issues

With the current `AllowAnyOrigin()` configuration, CORS issues should be minimal. However, if you encounter problems:

1. **Restart the API** after making configuration changes
2. **Check browser developer tools** for specific error messages
3. **Clear browser cache** if you've made recent changes
4. **Verify API is running** on the expected port

## Production Considerations

For production deployment, replace `AllowAnyOrigin()` with specific origins:
```csharp
policy.WithOrigins("https://yourdomain.com", "https://www.yourdomain.com")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials(); // Can be used with specific origins
```