"# GenerateSoluctionCoreNet"

-> Ingresar a carpeta de proyecto

-> Ejecutar "dotnet run -- new"

-> Instalar el nuget "Microsoft.EntityFrameworkCore 9.0.10" en el proyecto "RepositoryEntityFrameworkSqlServer"

-> Instalar el nuget "Microsoft.EntityFrameworkCore.SqlServer 9.0.10" en el proyecto "WebApi"
-> Instalar el nuget "MediatR 14.0.0" en el proyecto "WebApi"
-> Instalar el nuget "FluentValidation.DependencyInjectionExtensions 12.1.1" en el proyecto "WebApi"

-> Instalar el nuget "MediatR 14.0.0" en el proyecto "Application"
-> Instalar el nuget "FluentValidation 12.1.1" en el proyecto "Application"

-> Modificar Conexion Script
"ConnectionStrings": {
"ConexionDb": "Server=DESKTOP-DU0MO1P\\SQLEXPRESS;Database=Tekus_PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;"
},
