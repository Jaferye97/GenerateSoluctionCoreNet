"# GenerateSoluctionCoreNet"

-> Ingresar a carpeta de proyecto "CoreNet8.Cli"

-> Ejecutar "dotnet run -- new"

-> Instalar el nuget "Microsoft.EntityFrameworkCore 9.0.10" en el proyecto "RepositoryEntityFrameworkSqlServer"
-> Instalar el nuget "Microsoft.EntityFrameworkCore.SqlServer 9.0.10" en el proyecto "WebApi"

-> Modificar Conexion Script
"ConnectionStrings": {
"ConexionDb": "Server=DESKTOP-DU0MO1P\\SQLEXPRESS;Database=Tekus_PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;"
},
