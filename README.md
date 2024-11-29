# Proyecto API
Este proyecto es una API construida con .NET 8 y utiliza Entity Framework Core para la gestión de la base de datos.
## Requisitos
- .NET 8 SDK
- SQL Server
## Configuración del Proyecto
1. Clona el repositorio:
   
2. Restaura los paquetes NuGet:
   
3. Configura la cadena de conexión en `appsettings.json`:
"ConnectionStrings": {
   "DefaultConnection": "Server=DESKTOP-KU2O69E;Database=Crud_Javier;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
 }
4. Aplica las migraciones pendientes y actualiza la base de datos:
•	dotnet ef database update NombreMigracion --project Api/Api.csproj
•	dotnet ef database update

## Paquetes NuGet Utilizados

1.	`Microsoft.AspNetCore.Identity.EntityFrameworkCore` (8.0.10)
2.	`Microsoft.EntityFrameworkCore` (9.0.0)
3.	`Microsoft.EntityFrameworkCore.SqlServer` (9.0.0)
4.	`Microsoft.EntityFrameworkCore.Tools` (9.0.0)



Micro servicios
-	Seguridad
-	Registrase 
-	Login (Obtenemos el token)
-	Crud Tareas 
-	Guardar 
Sin el token nos devuelve 401,probamos en swagger 
-	 
Hacemos la prueba con postmam enviándole el token
-	Lista
-	Editar
 
