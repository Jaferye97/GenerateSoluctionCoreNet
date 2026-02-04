# GenerateSolutionCoreNet

## 📌 Descripción
Plantilla base para solución .NET con arquitectura limpia, EF Core, MediatR y FluentValidation.

---

## ✅ Prerrequisitos

- .NET SDK 8 o superior
- SQL Server / SQL Server Express
- Visual Studio 2022 o VS Code

---

## 🚀 Instalación

### 1. Clonar repositorio

```
git clone <repo-url>

cd .\GenerateSoluctionCoreNet\

cd .\CoreNet8.Cli\
```

### 2. Crear solución/proyecto

```
dotnet run -- new
```

### 3. Instalar paquetes NuGet
#### RepositoryEntityFrameworkSqlServer

```
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.10
```

#### Application

```
dotnet add package MediatR --version 14.0.0
dotnet add package FluentValidation --version 12.1.1
```

#### WebApi

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.10
dotnet add package MediatR --version 14.0.0
dotnet add package FluentValidation.DependencyInjectionExtensions --version 12.1.1
```

---

## ⚙️ Configuración

#### 1. Editar appsettings.json:
```
"ConnectionStrings": {
  "ConexionDb": "Server=YOUR_SERVER;Database=Tekus_PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Ejemplo:

```
"ConnectionStrings": {
  "ConexionDb": "Server=DESKTOP-DU0MO1V\\SQLEXPRESS;Database=PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;"
},
```


