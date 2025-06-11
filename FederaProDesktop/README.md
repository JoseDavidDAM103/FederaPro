# 🖥️ FederaProDesktop

**FederaProDesktop** es la aplicación de escritorio de **FederaPro**, desarrollada en **C# con Windows Forms**. Proporciona una interfaz completa para la gestión de datos deportivos, incluyendo jugadores, equipos, competiciones, partidos y estadísticas, actualmente soportando los módulos de **baloncesto** y **karting**.

---

## 🛠️ Tecnologías utilizadas

- 👨‍💻 C# (.NET Framework)
- 🪟 Windows Forms
- 🌐 Consumo de API REST (HttpClient)
- 📄 Integración con archivos CSV (importación/exportación)
- 🧩 Diseño modular por deporte

---

## 📂 Estructura del proyecto

```
desktop/
├── FederaProDesktop.sln                # Solución principal
├── FederaProDesktop/
│   ├── Program.cs                      # Entrada principal
│   ├── Login/                          # Pantallas de login y registro
│   ├── Basket/                         # Interfaces y servicios para baloncesto
│   ├── Karting/                        # Interfaces y servicios para karting
│   ├── Services/                       # Servicios para acceder a la API
│   ├── Models/                         # DTOs utilizados por la interfaz
│   └── Utils/                          # Funciones auxiliares
└── README.md
```

---

## ⚙️ Requisitos

- Visual Studio 2022+
- .NET Framework 4.7.2 o superior
- Backend corriendo en `http://localhost:8080`

---

## ▶️ Ejecución

1. Abre `FederaProDesktop.sln` en Visual Studio.
2. Verifica la URL base de la API en los servicios (por defecto `http://localhost:8080`).
3. Ejecuta el proyecto (`F5` o botón **Iniciar**).

---

## 🔑 Funcionalidades por módulo

### 🏀 Baloncesto

- Gestión de jugadores y equipos.
- Creación y edición de competiciones y partidos.
- Registro de estadísticas de jugador y equipo por partido.
- Clasificación por jornadas.

### 🏁 Karting

- Gestión de pilotos y circuitos.
- Creación de competiciones y carreras.
- Registro de resultados por piloto.
- Clasificación general por puntos acumulados.

---

## 🖱️ Interfaz

- Edición directa en celdas de tablas (jugadores, pilotos, etc.)
- Doble clic para abrir formularios de detalle.
- Botones `Guardar` y `Cancelar` para confirmar o descartar cambios.
- Filtros dinámicos por nombre, dorsal, posición, etc.

---

## 🧪 Pruebas

Actualmente se realizan pruebas manuales desde la interfaz. Los formularios y servicios están diseñados para ser fácilmente verificables por funcionalidad.

---

## 📌 Observaciones

- La aplicación asume que el backend está disponible en `http://localhost:8080`. Si usas otro puerto o dominio, cambia la URL en los servicios (`ApiService.cs`, `JugadorApiService.cs`, etc.).
- No requiere instalación adicional de librerías externas.

---

## 👨‍💻 Autor

Desarrollado por **José David Casas Gómez** como parte de la solución multiplataforma **FederaPro**.

---

## 📬 Contacto

- Email: [josedavid.casasgomez@iesmiguelherrero.com]
- Proyecto general: [https://github.com/JoseDavidDAM103/FederaPro](https://github.com/JoseDavidDAM103/FederaPro)
