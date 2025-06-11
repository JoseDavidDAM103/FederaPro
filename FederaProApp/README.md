# 📱 FederaProApp (Android)

**FederaProApp** es la aplicación móvil de **FederaPro**, desarrollada en **Kotlin** para Android. Está centrada en la **visualización de datos deportivos** como clasificaciones, partidos, carreras y estadísticas, adaptándose a los deportes actualmente soportados: **baloncesto** y **karting**.

---

## 📦 Tecnologías utilizadas

- 🤖 Kotlin (Android API 26+)
- 🧭 Jetpack Navigation
- 🌐 Retrofit (para llamadas HTTP)
- 🎨 Material Design
- 📊 Gráficas interactivas (custom drawables)
- 🧱 Arquitectura basada en fragmentos

---

## 📂 Estructura del proyecto

```
mobile/
├── app/
│   ├── src/
│   │   ├── main/
│   │   │   ├── java/com/federaproapp/
│   │   │   │   ├── data/                     # Modelos para el login
│   │   │   │   ├── basket/                   # Vistas y lógica para baloncesto
│   │   │   │   ├── karting/                  # Vistas y lógica para karting
│   │   │   │   ├── api/                      # Llamadas a la API (Retrofit)
│   │   │   │   └── ui/                       # Funciones auxiliares
│   │   │   └── res/                          # Layouts, drawables, strings, etc.
│   ├── build.gradle
├── README.md
```

---

## ⚙️ Requisitos

- Android Studio Giraffe o superior
- Emulador o dispositivo físico (API 26+)
- Backend ejecutándose localmente o accesible desde red

---

## ▶️ Ejecución

1. Abre la carpeta `mobile/` en Android Studio.
2. Conecta un dispositivo o lanza un emulador.
3. Ejecuta el proyecto (`Run > Run app`).

> La app espera que la API esté disponible en `http://10.0.2.2:8080` (si se usa emulador).

---

## 🧩 Módulos funcionales

### 🏀 Baloncesto

- Clasificación de equipos por competición.
- Lista de partidos y sus resultados.
- Gráficas de rendimiento por jugador.
- Detalle de estadísticas individuales.

### 🏁 Karting

- Clasificación de pilotos por puntos acumulados.
- Lista de carreras y circuitos.
- Rankings de podios, victorias y vueltas completadas.
- Comparación visual entre pilotos.

---

## 📈 Estadísticas y gráficas

- Selector de tipo de gráfica: barras, radar, circular.
- Interacción táctil para ver detalle de un jugador/piloto.
- Resumen visual dinámico y filtrado.

---

## 🔐 Login

- Pantalla de inicio de sesión funcional (integrada con la API).
- Se requiere una cuenta válida (registro desde escritorio por ahora).

---

## 🧪 Pruebas

- Pruebas manuales realizadas desde interfaz.
- Flujo validado: login → selección de módulo → navegación por estadísticas.

---

## 🛠️ En desarrollo

- Mejoras en la experiencia de usuario (UX).
- Módulo de notificaciones y favoritos.
- Sistema de perfiles y personalización futura.

---

## 👨‍💻 Autor

Desarrollado por **José David Casas Gómez** como parte del ecosistema multiplataforma **FederaPro**.

---

## 📬 Contacto

- Email: [josedavid.casasgomez@example.com]
- Proyecto general: [https://github.com/JoseDavidDAM103/FederaPro](https://github.com/JoseDavidDAM103/FederaPro)
