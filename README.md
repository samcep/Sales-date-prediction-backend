# Sales Date Prediction  Backend
<img width="1658" height="906" alt="4mock" src="https://github.com/user-attachments/assets/eb483019-c169-4359-a26f-0191a1ab102b" />

Este proyecto es una API construida con **.NET 8 Web API** y utiliza **Entity Framework Core** para el acceso a datos.

## Requisitos previos

- .NET 8 SDK
- SQL Server (local o remoto)
- Configuración de la cadena de conexión en `appsettings.development.json`

## Configuración de la conexión a la base de datos

En el archivo `appsettings.development.json` se debe definir la cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SalesDatePrediction;User Id=sa;Password=tu_password;TrustServerCertificate=True;"
}
```

## Configuración de CORS

El CORS está habilitado para permitir peticiones desde el frontend. En `appsettings.development.json` se debe configurar la URL permitida:

```json
"allowedUrl": "http://localhost:4200"
```

Esto permite que Angular consuma la API durante el desarrollo.

## Instalación

1. Clonar el repositorio.
2. Restaurar dependencias con:
   ```
   dotnet restore
   ```
3. Aplicar las migraciones de la base de datos:
   ```
   dotnet ef database update
   ```

## Levantar el servidor de desarrollo

Ejecutar:

```
dotnet run
```

La API estará disponible en `https://localhost:7239` (puerto configurable).

## Swagger

En modo desarrollo, Swagger estará disponible en:

```
https://localhost:7239/swagger
```

