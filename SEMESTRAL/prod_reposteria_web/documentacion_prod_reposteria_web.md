# Documentación del Proyecto PROD_REPOSTERIA_WEB

## 1. Descripción General
**PROD_REPOSTERIA_WEB** es una aplicación web desarrollada en **ASP.NET Web Forms (.NET Framework)** cuyo objetivo es gestionar y mostrar un catálogo de postres para una repostería. El sistema cuenta con un **catálogo público**, un **panel administrativo**, autenticación básica por roles y funcionalidades de **reportes**, cumpliendo con los lineamientos académicos del curso.

La aplicación implementa operaciones CRUD, consumo de una API externa para imágenes, manejo de sesiones y separación clara entre funcionalidades públicas y administrativas.

---

## 2. Tecnologías Utilizadas
- **Lenguaje:** C#
- **Framework:** ASP.NET Web Forms (.NET Framework)
- **Base de datos:** SQL Server
- **Acceso a datos:** ADO.NET (SqlConnection, SqlCommand, Stored Procedures)
- **Frontend:** HTML, CSS, Bootstrap
- **Gestión de estado:** Session
- **APIs externas:** Picsum (imágenes)
- **Servidor local:** IIS Express

---

## 3. Arquitectura del Proyecto

### 3.1 Estructura General
```
PROD_REPOSTERIA_WEB
│
├── Admin
│   ├── Postres.aspx        # CRUD de postres (Admin)
│   ├── Reportes.aspx       # Reportes del sistema (Admin)
│
├── App_Data                # Recursos locales
├── Content                 # Estilos CSS
├── Scripts                 # Librerías JS
├── Catalogo.aspx           # Catálogo público
├── Login.aspx              # Autenticación
├── Default.aspx            # Página pública inicial
├── Site.Master             # Master Page
├── Web.config              # Configuración general
```

### 3.2 Separación de Roles
- **Usuario público:** Accede al catálogo y simulación de compra.
- **Administrador:** Gestiona postres y visualiza reportes.

---

## 4. Funcionalidades del Sistema

### 4.1 Autenticación (Login)
- Inicio de sesión mediante **Email + Password**.
- Uso de **consultas parametrizadas** para evitar SQL Injection.
- Almacenamiento de sesión para identificar al usuario autenticado.
- Diferenciación de rol **Admin / Usuario**.

---

### 4.2 Gestión de Postres (Administrador)
**Ubicación:** `/Admin/Postres.aspx`

#### Funcionalidades:
- Crear postres
- Editar postres existentes
- Eliminar postres
- Listar postres en GridView

#### Campos gestionados:
- Nombre
- Descripción
- Precio
- Imagen (URL obtenida desde API externa)

#### Detalles técnicos:
- Uso de **Stored Procedures**:
  - `sp_postres_insertar`
  - `sp_postres_actualizar`
  - `sp_postres_eliminar`
  - `sp_postres_listar`
- Manejo de estado mediante `HiddenField` para diferenciar INSERT / UPDATE.

---

### 4.3 Integración con API Externa (Imágenes)
- Al crear un nuevo postre, el sistema obtiene una imagen desde la API **Picsum**.
- Se almacena la **URL de la imagen** en la base de datos.
- No se gestionan archivos físicos en el servidor, evitando problemas de carga.

Ejemplo de URL utilizada:
```
https://picsum.photos/id/1080/300/200
```

---

### 4.4 Catálogo Público
**Ubicación:** `/Catalogo.aspx`

#### Funcionalidades:
- Visualización de postres en formato de tarjetas.
- Imagen, nombre, descripción y precio visibles.
- Botón **"Agregar al carrito"**.

#### Implementación:
- Uso de **Repeater** para renderizar dinámicamente el catálogo.
- Consulta directa a la base de datos.

---

### 4.5 Compra Simulada / Carrito
- Simulación de compra mediante botón.
- Uso de **Session** para almacenar productos seleccionados.
- Mensaje de confirmación al usuario.

> Nota: No se procesa pago real, cumpliendo con el enfoque académico del proyecto.

---

### 4.6 Reportes del Sistema (Administrador)
**Ubicación:** `/Admin/Reportes.aspx`

#### Reportes disponibles:
- Total de postres registrados
- Precio promedio de los postres
- Postre más caro
- Postre más barato

#### Implementación técnica:
- Consultas SQL agregadas
- Resultados mostrados mediante `Label`
- Acceso restringido a usuarios Administradores

---

## 5. Seguridad
- Uso de **consultas parametrizadas** (prevención de SQL Injection).
- Separación de páginas administrativas.
- Control de acceso mediante **Session**.
- Validación de roles para acceso a Admin.

---

## 6. Base de Datos

### Tabla principal: `Postres`
Campos relevantes:
- IdPostre (PK)
- Nombre
- Descripcion
- Precio
- Imagen
- Activo
- FechaCreacion

### Stored Procedures
- Inserción
- Actualización
- Eliminación
- Listado

---

## 7. Cumplimiento de Requisitos Académicos
✔ Uso de ASP.NET Web Forms
✔ Conexión a base de datos
✔ CRUD completo
✔ Separación de roles
✔ Consumo de API externa
✔ Reportes estadísticos
✔ Manejo de sesiones

---

## 8. Conclusión

**PROD_REPOSTERIA_WEB** es una aplicación web funcional, estructurada y escalable, que demuestra el uso correcto de ASP.NET Web Forms, ADO.NET, bases de datos relacionales y consumo de servicios externos. El proyecto cumple satisfactoriamente con los objetivos del curso y sienta bases sólidas para futuras ampliaciones como pagos reales, manejo avanzado de usuarios o despliegue en producción.

---

📌 *Documentación elaborada con enfoque profesional y académico.*

