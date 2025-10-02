# 🔐 Authentication Flow

## Overview
The application implements a simple token-based authentication system with two layout modes:
- **LoginLayout**: Simple layout without menus (for unauthenticated users)
- **MainLayout**: Full layout with navigation sidebar (for authenticated users)

## Authentication Process

### 1. Login Page (`/`)
- Uses `LoginLayout` (no navigation menus)
- User enters email and password
- Credentials sent to API endpoint: `POST /api/Usuarios/login`
- On success:
  - Token stored in memory via `AuthService`
  - User info stored in `AuthService.CurrentUser`
  - Redirects to `/menu`
- On failure:
  - Error message displayed

### 2. Token Storage
The `AuthService` class stores authentication state in memory:
```csharp
private string? _token;
private UsuarioResponse? _currentUser;

public bool IsAuthenticated => !string.IsNullOrEmpty(_token);
```

**Note**: Token is stored in memory only (not persisted). User must log in again if they:
- Close the browser
- Refresh the page
- Application restarts

### 3. Protected Pages
All authenticated pages implement this check in `OnInitializedAsync()`:
```csharp
protected override async Task OnInitializedAsync()
{
    if (!AuthService.IsAuthenticated)
    {
        Navigation.NavigateTo("/", true);
        return;
    }
    // ... load page data
}
```

Protected pages include:
- `/menu` - Main menu
- `/cardapio` - Menu items management
- `/mesas` - Tables management
- `/usuarios` - Users management
- `/comandas` - Orders management
- `/pedidos` - Kitchen orders

### 4. Logout
Users can logout from the Menu page:
- Click "Sair" button
- Calls `AuthService.Logout()` which clears token and user info
- Redirects to login page (`/`)

## Layout Structure

### LoginLayout
```
┌─────────────────────┐
│                     │
│   Login Form        │
│   (centered)        │
│                     │
└─────────────────────┘
```

### MainLayout (After Authentication)
```
┌──────┬──────────────┐
│      │              │
│ Nav  │  Page        │
│ Menu │  Content     │
│      │              │
└──────┴──────────────┘
```

## API Configuration
The API base URL is configured in `Program.cs`:
```csharp
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5163/") 
});
```

## Security Notes
⚠️ **Important Limitations**:
1. Token stored in memory only (not persistent)
2. No token refresh mechanism
3. No token expiration handling
4. No secure HTTP-only cookies
5. Suitable for development/internal use only

For production use, consider:
- Persistent token storage (encrypted)
- Token refresh mechanism
- HTTP-only cookies
- Session timeout
- HTTPS enforcement
