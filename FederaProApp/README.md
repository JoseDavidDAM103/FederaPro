# 📡 FederaProApi

**FederaProApi** es el backend de la plataforma FederaPro. Está desarrollado con **Java 17** y **Spring Boot**, y expone una API RESTful para la gestión completa de datos deportivos relacionados con diferentes disciplinas, actualmente **baloncesto** y **karting**.

---

## 🚀 Tecnologías utilizadas

- 🧠 Java 17
- ⚙️ Spring Boot
- 🗄️ JPA (Hibernate)
- 🧪 JUnit 5
- 🔒 Spring Security (parcial, en desarrollo)
- 🛢️ MySQL / MariaDB
- 🌐 RESTful API con JSON

---

## 📂 Estructura del proyecto

```
FederaProApi/
├── src/
│   ├── main/
│   │   ├── java/example/com/federapro         # Código fuente principal
              ├── basket                       # Modelos, Controllers, Servicios y Repositorios de baloncesto
              ├── configuracion                # Modelos, Controllers, Servicios y Repositorios de Configuración
              ├── karting                      # Modelos, Controllers, Servicios y Repositorios de Karting
              ├── Utils/enum                   # Enumerados
│   │   └── resources/                         # Configuración (application.properties, etc.)
│   └── test/                                  # Tests unitarios
├── pom.xml                                    # Configuración de Maven
└── README.md
```

---

## ⚙️ Configuración inicial

### 1. Requisitos previos

- Java 17+
- Maven 3.8+
- MySQL o MariaDB
- IDE recomendado: IntelliJ IDEA

### 2. Configura la base de datos

Crea una base de datos en tu gestor (ej. `federapro_db`) y configura el archivo `src/main/resources/application.properties`:

```properties
spring.datasource.url=jdbc:mysql://localhost:3306/federapro?useUnicode=true&characterEncoding=UTF-8&characterSetResults=UTF-8
spring.datasource.username=root
spring.datasource.password=mysql
spring.datasource.driver-class-name=com.mysql.cj.jdbc.Driver
spring.jpa.hibernate.ddl-auto=none
spring.jpa.show-sql=true


# Habilitar la carga de archivos en Spring Boot
spring.servlet.multipart.enabled=true
spring.servlet.multipart.max-file-size=2MB
spring.servlet.multipart.max-request-size=2MB

spring.security.user.name=user
spring.security.user.password=password

server.address=0.0.0.0
```

### 3. Ejecuta el backend

Desde terminal:

```bash
./mvnw spring-boot:run
```

> La API se expondrá en: `http://localhost:8080`

---

## 📚 Endpoints destacados

### Baloncesto

- `/basket/equipos` → Gestión de equipos
- `/basket/jugadores` → Gestión de jugadores
- `/basket/partidos` → CRUD de partidos
- `/basket/estadisticas` → Estadísticas por partido

---

### Karting

- `/api/configuraciones` → Gestión de configuraciones
- `/api/deportes` → Gestión de deportes
- `/api/usuarios` → Gestión de Usuarios

---

### Karting

- `/karting/pilotos` → Gestión de pilotos
- `/karting/circuitos` → Gestión de circuitos
- `/karting/carreras` → Gestión de carreras
- `/karting/estadisticas` → Estadísticas por piloto

---

## 🔐 Seguridad (en progreso)

Actualmente el login está implementado en la app de escritorio y móvil. La validación de credenciales contra el backend se está desarrollando con Spring Security.

---

## 🛠️ Futuras mejoras

- Autenticación JWT
- Control de acceso por roles
- Soporte para más deportes

---

## 👨‍💻 Autor

Desarrollado por **José David Casas Gómez** como parte del sistema de gestión deportiva **FederaPro**.

---

## 📬 Contacto

- Email: [josedavid.casasgomez@example.com]
- Proyecto general: [https://github.com/JoseDavidDAM103/FederaPro](https://github.com/JoseDavidDAM103/FederaPro)
