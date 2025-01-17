﻿# Catedra3IDWM_Backend

Este proyecto es una API backend para gestionar posts y usuarios, desarrollado con .NET y una base de datos SQLite. Utiliza JWT para la autenticación y servicios adicionales como Cloudinary para la gestión de imágenes.

## Requisitos previos

1. **Node.js** (v16 o superior)
   - Necesario si también está trabajando con el frontend.
2. **.NET SDK** (v7.0 o superior)
   - [Descargar desde el sitio oficial](https://dotnet.microsoft.com/download).
3. **SQLite**
   - Incluido en el proyecto, no requiere instalación adicional.
4. **Visual Studio Code**
   - Recomendado para la edición y depuración del código.
5. **Postman**
   - Para probar los endpoints de la API.

## Instalación

1. Clona este repositorio:

   ```bash
   git clone https://github.com/Hvmnn/Catedra3IDWM_Backend.git
   cd Catedra3IDWM_Backend
   ```

2. Restaura las dependencias:

   ```bash
   dotnet restore
   ```

3. Compila el proyecto para asegurarte de que todo esté correcto:

   ```bash
   dotnet build
   ```

## Configuración de variables de entorno

En el archivo `appsettings.json` en el directorio raiz del proyecto, reemplaza las siguientes configuraciones con tus respectivos datos:

```json
{
  "Jwt": {
    "Key": "TU_CLAVE_SECRETA",
    "Issuer": "Catedra3Backend",
    "Audience": "localhost:5168"
  },
  "Cloudinary": {
    "CloudName": "TU_CLOUD_NAME",
    "ApiKey": "TU_API_KEY",
    "ApiSecret": "TU_API_SECRET"
  }
}
```

Asegúrate de reemplazar los valores con tus credenciales de Cloudinary y la clave secreta de JWT.

## Comandos para ejecutar el proyecto

1. Ejecutar las migraciones de la base de datos:

   ```bash
   dotnet ef migrations add InitialCreate
   ```


2. Para ejecutar la aplicación en modo de desarrollo:

   ```bash
   dotnet run
   ```

   Esto iniciará el servidor en `https://localhost:5168`.

3. Para probar los endpoints en Swagger:

   Dirígete a `https://localhost:5168/swagger` en tu navegador.

¡Listo! Ahora puedes trabajar con el backend de manera local. 🚀
