**Test Finanzauto**

**Instrucciones para Ejecutar las aplicaciones**
1. Clonar el repositorio -> git clone https://github.com/dannywilches/testfinanzauto.git
2. Una vez clonado el repositorio navegamos dentro de la carpeta -> cd testfinanzauto
3. Alli ejecutar el docker compose -> docker compose up -d (Nota: Tener instalado el Docker Desktop)
4. Compose levantara 3 contenedores
	- Base de Datos en PostgreSQL
	- Contenedor del Backend
	- Contenedor del Frontend
5. No es necesario ejecutar, la aplicación por si sola creará la BD y sus respectivas tablas
6. El backend estará corriendo sobre el puerto 5001, en caso de querer ver el swagger ir a -> http://localhost:5001/swagger/index.html
7. El fronted estará corriendo sobre el puerto 5002, para ingresar ir a -> http://localhost:5002
8. Si se quiere importar la collection en Postman por ejemplo, importar desde esta URL -> http://localhost:5001/swagger/v1/swagger.json
9. Para Iniciar Sesión se crearon unas credenciales para pruebas -> Usuario: admin - Contraseña: 123456
10. Desde aquí ya se podrá interactuar con el Front y las funcionalidades implementadas

**ARQUITECTURA DE LA SOLUCIÓN**

* La solución de la prueba tiene dos partes el Backend y el Frontend.

**TFA Backend API**
* Esta desarrollada en .NET 8, implementado Clean Architecture, DDD (Domain-Driven-Design), empleando SOLID y CQRS de forma ligera.
* En ella se contemplan un servicio para la autenticación con JWT la cual provee un Token que servirá para consumir los demás endpoints.

# La solución esta organizada en 4 capas + 1 proyecto de Tests

*TFA.Backend.Api*
Este proyecto centraliza la exposición de los endpoints REST
Recepcion y validación de solicitudes HTTP
Autenticación y Autorización en los diferentes métodos

*TFA.Backend.Application*
Commands/Queries que implementa patrón CQRS de una forma ligera, para separar las operaciones de lectura y escritura
DTOs para el manejo de los Request y Response de los endpoints con el fin de no exponer las entidades del sistema
Interfaces que corresponden a los contratos de los servicios, Handlers de la capa de Applicación
Handlers que ejecutan las diferentes operaciones

*TFA.Backend.Domain*
Centraliza las entidades del Dominio que solo pueden ser referenciadas desde la capa de Application e Infrastructure
Contratos de los repositorios 

*TFA.Backend.Infrastructure*
Persistencia, contiene todo lo necesario para la conexión a la Base de Datos
En esta se encuentran las implementaciones de los Repositorios, Mapeadores, Modelos de la Base de Datos, Migraciones y Configuraciones de las tablas
Implementación de JWT donde realiza la generación del Token y así misma la validación del mismo

*TFA.Backend.Tests*
Proyecto donde se realizaron un par de pruebas sencillas


**DDD - Domain Driven Design**
Se implementó un enfoque por capas basado en DDD donde hace uso de los principios de SOLID
Responsabilidad Simple donde cada componente tiene una sola responsabilidad
Open/Closed que permite extender funcionalidades sin modificar la existentes
Segregación de interfaces, ya que implementa contratos (interfaces) en toda su funcionalidad
Inversión de dependencias ya que la aplicación depende de los contratos y no de las implementaciones directas
Esta arquitectura permite que si el proyecto crece se facil de mantener y legible

# Endpoints
Como se explico en el despliegue la collection trae todos los métodos que se pueden usar
Todos se encuentran protegidos, es decir que para ser consumidos es necesario enviar el Token de Autenticación
El único método no protegido es el del Login, el cual se puede consumir con las credenciales suministradas al inicio
Para el punto en que se solicita que se puedan cargar 100.000 productos se integro un método que es POST `/api/products/bulk`
Este método genera productos aleatorios enviando como parametros la cantidad a crear (quantity) y los ID del Proveedor (supplierID) y Categoria (categoryID)

# Aspectos de la Solución
- Para las consultas de productos si implementó paginación y filtros de busqueda los cuales están optimizados para no generar un consumo alto en la BD
- Para el cargue masivo se implementó un procesamiento por lotes, el cual va creando los productos por lotes de 1000, esto con el fin de optimizar el consumo de la memoria
mejorar el rendimiento a nivel general, minimizar el número de operaciones sobre la BD y se incluyó una Cancelación en dado caso que la petición sea cancelada o detenida o se interrumpa, el proceso se detendrá

# Escalabilidad y Performance
Para el procesamiento de cargas altas tal como se menciono una solución fue realizar los batch o procesamiento por lotes, sin embargo otra solución que es viable 
es implementar un proceso de encolamiento por ejemplo con RabbitMQ donde las cargas altas y/o masivas se envían a la cola y luego un WorkerService estará procesando
todas las cargas, con el fin de garantizar que los procesamientos sean ejecutados, así mismo para el escalamiento horizontal se puede implementar un Balanceador de 
Carga el cual distribuira dichas cargas


**TFA Frontend UI**
* La solución del front se desarrollo en React, de acuerdo con los requisitos de la prueba.
* Se incluyo la autenticación con JWT, cuando se realiza la autenticación exitosa guarda el Token en Local Storage
* También se incluyó un ProtectedRoute que equivale a un AuthGuard en donde está validando el estado del Token y si se vence redirige al Login
* Se implemento el interceptor que agrega el Token a todos los request que van al Backend para poder consumirlos
* Para la sección de productos se incluyeron las funcionalidades de un CRUD
- Consulta de todos los productos son su paginación y filtros
- Creación de nuevos productos
- Actualización de productos
- Eliminación de productos
* Los formularios de creación y actualización incluyen validaciones sencillas pero útiles que muestran en pantalla los errores de cada validación
