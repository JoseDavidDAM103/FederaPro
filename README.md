# 🏆 FederaPro

**FederaPro** es una plataforma integral para la **gestión de federaciones deportivas**, diseñada para adaptarse dinámicamente a distintos deportes. Proporciona herramientas para la administración de **equipos, jugadores, competiciones, partidos y estadísticas**, todo desde una arquitectura modular y multiplataforma.

Actualmente implementa módulos completos para **baloncesto** y **karting**.

---

## 📦 Tecnologías principales

| Componente         | Tecnología                    |
|--------------------|-------------------------------|
| Backend API        | Java 17 + Spring Boot         |
| Escritorio         | C# (Windows Forms, .NET)      |
| App móvil          | Kotlin (Android API 26+)      |
| Base de datos      | MySQL / MariaDB               |
| Comunicación       | REST API (JSON)               |

---

## 🧭 Estructura del repositorio

```
FederaPro/
├── FederaPro/                         # API REST con Spring Boot
├── FederaProDesktop/                  # Aplicación Windows Forms en C#
├── FederaProApp/                      # App Android nativa en Kotlin
├── Documentación/                     # Documentación técnica del proyecto
└── README.md                 
```

---

## 🚀 Características destacadas

### 🔄 Modularidad por deporte
Cada deporte implementa su propia lógica, entidades y vistas:
- **Baloncesto**: jugadores, estadísticas individuales y de equipo, jornadas y competiciones.
- **Karting**: pilotos, circuitos, carreras, clasificación por puntos.

### 🖥️ Gestión completa desde escritorio
- ABM (Alta, Baja, Modificación) de entidades como equipos, jugadores, competiciones y estadísticas.
- Edición en tabla, formularios personalizados, carga/descarga CSV.

### 📱 Visualización en la app móvil
- Clasificación actualizada de equipos o pilotos.
- Lista de partidos/carreras.
- Gráficas de rendimiento individual por jugador/piloto.

### 📈 Estadísticas detalladas
- Baloncesto: puntos, asistencias, rebotes, tapones, minutos jugados, etc.
- Karting: posición final, vueltas completadas, tiempo total, podios, victorias.

---

## 🧪 Pruebas y calidad

- ✔️ Validaciones en formularios de escritorio
- ✔️ Validación de flujo de uso manual en app móvil

---

## 🔐 Seguridad

- Sistema de login funcional en la aplicación de escritorio y móvil (en desarrollo).
- Comunicación API vía HTTP o HTTPS (según configuración).
- Preparado para futura integración de control de roles.

---

## 📚 Documentación técnica

Toda la documentación detallada se encuentra en la carpeta `/docs/`, incluyendo:

- 📄 Análisis del contexto y estado del arte
- 🧩 Diseño de base de datos y diagramas de clase
- 📜 Casos de uso y flujos del sistema
- 📘 Manual de usuario y plan de pruebas

---

## 📌 Estado del proyecto

| Módulo       | Estado         | Observaciones                                      |
|--------------|----------------|----------------------------------------------------|
| Backend      | ✅ Completo     | Soporta baloncesto y karting con endpoints REST    |
| Escritorio   | ✅ En uso       | Interfaces completas y funcionales                |
| Android App  | 🛠️ En progreso | Visualización y gráficas listas, login en desarrollo |
| Docs         | ✅ Avanzado     | Disponible en `/docs`                             |

---

## 🙋‍♂️ Autor

Desarrollado por **José David Casas Gómez**  
Proyecto modular para la gestión de federaciones deportivas.

---

## 📄 Licencia

Este proyecto está licenciado bajo la **MIT License**. Puedes ver más detalles en el archivo `LICENSE`.

---

## 📬 Contacto

Para soporte, sugerencias o colaboración:

- ✉️ Email: [josedavid.casasgomez@iesmiguelherrero.com]
- 📦 GitHub: [https://github.com/JoseDavidDAM103/FederaPro](https://github.com/JoseDavidDAM103/FederaPro)
