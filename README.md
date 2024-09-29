# Cliente-Servidor para Gestión de Productos

Este proyecto es una implementación básica de un sistema cliente-servidor en C# que permite gestionar productos. Utiliza una arquitectura de cliente-servidor, donde el cliente envía solicitudes al servidor para agregar nuevos productos y ver la lista de productos existentes. El servidor se comunica con una base de datos SQL Server para almacenar y recuperar información sobre los productos.

## Características

- **Agregar Producto**: Permite al usuario ingresar un nuevo producto con nombre y precio.
- **Ver Productos**: Muestra todos los productos almacenados en la base de datos.
- **Interfaz de Línea de Comando**: Interacción simple y directa a través de la terminal.
  
## Tecnologías Utilizadas

- **C#**: Lenguaje de programación principal.
- **ASP.NET Core**: Framework para construir la API del servidor.
- **SQL Server**: Base de datos para almacenar la información de los productos.
- **HttpClient**: Para realizar solicitudes HTTP desde el cliente al servidor.
- **Newtonsoft.Json**: Para la serialización y deserialización de objetos JSON.

## Requisitos Previos

Asegúrate de tener instalados los siguientes programas:

- .NET SDK
- SQL Server (o SQL Server Express)
- Un editor de código (como Visual Studio o Visual Studio Code)
