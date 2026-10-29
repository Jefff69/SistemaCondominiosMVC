# 🏘️ Sistema de Condominios

Sistema web para la gestión de un condominio, desarrollado como proyecto académico para el curso **Programación VI**. Su objetivo es administrar la información de las personas, casas, servicios y cobros de mensualidades, utilizando una arquitectura basada en ASP.NET MVC y SQL Server.

## 📌 Estado del proyecto

**En desarrollo.**

La aplicación cuenta con autenticación de usuarios, control de acceso por tipo de usuario, consultas de los principales módulos y procedimientos almacenados para las operaciones con la base de datos. Actualmente se trabaja en la integración del formulario MVC para crear cobros de mensualidades.

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework web:** ASP.NET MVC 5
- **Framework de destino:** .NET Framework 4.7.2
- **Base de datos:** Microsoft SQL Server Express
- **Acceso a datos:** ADO.NET
- **Interfaz:** HTML, CSS, Bootstrap y Razor
- **Entorno de desarrollo:** Visual Studio
- **Control de versiones:** Git y GitHub

## ✨ Funcionalidades

### Autenticación y seguridad

- Inicio y cierre de sesión.
- Validación de credenciales mediante un procedimiento almacenado.
- Control de acceso según el tipo de usuario.
- Restricción de acceso a determinadas secciones para clientes y empleados.
- Validación de sesión activa para acceder a las áreas protegidas.

### Módulos de consulta

- **Personas:** consulta de los registros de personas.
- **Casas:** consulta de las casas y sus propietarios.
- **Servicios:** consulta de los servicios disponibles.
- **Categorías:** consulta de las categorías de servicios.
- **Cobros:** consulta de los cobros, con filtrado según los permisos del usuario.

### Gestión de cobros

Se está desarrollando el flujo de creación de cobros de mensualidades.

El procedimiento almacenado `SP_RegistrarCobro` ya fue probado en SQL Server y permite:

- Validar la casa seleccionada y el periodo.
- Comprobar que no exista otro cobro pendiente para la misma casa y periodo.
- Calcular el monto del cobro según el precio de la casa, los metros cuadrados y los servicios seleccionados.
- Registrar el cobro y sus servicios asociados.
- Crear el registro correspondiente en la bitácora.
- Ejecutar las operaciones dentro de una transacción para mantener la consistencia de los datos.

La integración completa de este procedimiento con el formulario web está pendiente.

## 🗄️ Base de datos

La base de datos utilizada por el proyecto se llama `PVI_ProyectoFinal`.

Está compuesta por las siguientes tablas:

| Tabla | Descripción |
|---|---|
| `Persona` | Información de clientes y empleados. |
| `Casas` | Información de las casas del condominio. |
| `Categorias` | Categorías de los servicios. |
| `Servicios` | Servicios disponibles y sus precios. |
| `Cobros` | Cobros de mensualidades. |
| `DetalleCobro` | Relación entre los cobros y los servicios asociados. |
| `Bitacora` | Registro de las acciones realizadas sobre los cobros. |

Las operaciones de acceso a datos utilizan procedimientos almacenados de SQL Server, siguiendo los requerimientos académicos del proyecto.

## 🏗️ Estructura del proyecto

La solución está organizada siguiendo la estructura de un proyecto ASP.NET MVC 5.

```text
SistemaCondominiosMVC/
├── Controllers/
│   ├── CasasController.cs
│   ├── CategoriasController.cs
│   ├── CobrosController.cs
│   ├── HomeController.cs
│   ├── LoginController.cs
│   ├── PersonasController.cs
│   └── ServiciosController.cs
├── Data/
│   ├── AccesoDatos.cs
│   └── Conexion.cs
├── Filtros/
│   ├── EmpleadoAttribute.cs
│   └── SesionActivaAttribute.cs
├── Models/
│   ├── Casa.cs
│   ├── Categoria.cs
│   ├── Cobro.cs
│   ├── CrearCobroViewModel.cs
│   ├── LoginViewModel.cs
│   ├── Persona.cs
│   └── ServicioSeleccionableViewModel.cs
├── Views/
│   ├── Casas/
│   ├── Categorias/
│   ├── Cobros/
│   ├── Home/
│   ├── Login/
│   ├── Personas/
│   ├── Servicios/
│   └── Shared/
├── Web.config
└── SistemaCondominiosMVC.sln
```

*Nota: esta estructura representa los archivos principales identificados durante el desarrollo. La solución puede contener otros archivos y carpetas propios de Visual Studio.*

## ⚙️ Requisitos para ejecutar el proyecto

- Windows.
- Visual Studio con soporte para ASP.NET MVC 5 y .NET Framework 4.7.2.
- .NET Framework 4.7.2.
- SQL Server Express y SQL Server Management Studio (SSMS).
- Git, si se desea clonar el repositorio.

## 🚀 Instalación y ejecución

### 1. Clonar el repositorio

```bash
git clone [URL_DEL_REPOSITORIO](https://github.com/Jefff69/SistemaCondominiosMVC.git)
```

### 2. Abrir la solución

Abre `SistemaCondominiosMVC.sln` con Visual Studio.

### 3. Preparar la base de datos

Crea o restaura la base de datos `PVI_ProyectoFinal` en SQL Server y asegúrate de contar con las tablas, relaciones, datos de prueba y procedimientos almacenados requeridos por la aplicación.

### 4. Configurar la conexión

En `Web.config`, configura la cadena de conexión para que corresponda con la instancia de SQL Server de tu equipo.

Ejemplo de configuración local:

```xml
<connectionStrings>
    <add name="PVI_ProyectoFinal"
         connectionString="Data Source=TU_INSTANCIA_SQL;Initial Catalog=PVI_ProyectoFinal;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Sustituye `TU_INSTANCIA_SQL` por el nombre de tu instancia local. Si utilizas autenticación de SQL Server en lugar de autenticación integrada, configura la conexión de acuerdo con tu entorno.

### 5. Compilar y ejecutar

1. Compila la solución desde Visual Studio.
2. Verifica que la cadena de conexión sea correcta.
3. Ejecuta la aplicación con IIS Express.
4. Inicia sesión con una cuenta de prueba existente en la base de datos.

## 🧪 Pruebas realizadas

Durante el desarrollo se han comprobado:

- La conexión con SQL Server.
- La autenticación mediante `SP_ValidarLogin`.
- Las restricciones de acceso por sesión y tipo de usuario.
- La consulta de casas, personas, categorías, servicios y cobros.
- La consulta de personas activas, casas por persona y servicios activos.
- El registro de un cobro de prueba con sus servicios asociados y la correspondiente entrada en `Bitacora`.

El formulario MVC de creación de cobros y las demás operaciones pendientes deberán probarse antes de considerar finalizada la aplicación.

## 🔐 Seguridad y buenas prácticas

- Utilizar parámetros SQL en lugar de concatenar valores del usuario en las consultas.
- Mantener protegidas las credenciales y los datos sensibles.
- No publicar contraseñas, cadenas de conexión privadas ni información personal de los datos de prueba.
- Verificar los permisos tanto en el servidor como en la interfaz.
- Mantener las operaciones relacionadas dentro de transacciones cuando corresponda.

## 🎓 Propósito académico

Este proyecto forma parte del curso **Programación VI** y permite aplicar conocimientos de desarrollo web con ASP.NET MVC, programación en C#, acceso a bases de datos relacionales, procedimientos almacenados, validación de formularios, autenticación y control de acceso.

## 📄 Licencia

Proyecto desarrollado con fines académicos. No se ha definido una licencia de distribución.

---

**Proyecto:** Sistema de Condominios  
**Curso:** Programación VI  
**Tecnologías principales:** C#, ASP.NET MVC 5 y SQL Server  
**Estado:** En desarrollo
