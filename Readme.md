# Arquitectura de Software

---

## Elementos Clave

- Componentes
    Estos son las unidades funcionales del sistema, responsables de realizar tareas específicas.
- Relaciones
    Definen cómo interactúan los componentes entre sí.
- Responsabilidades
    Cada componente tiene responsabilidades claras que definen su propósito dentro del sistema.
- Reglas
    Normas que guían el diseño y la interacción de los componentes.

---

## ¿Para que sirve?

La arquitectura de software sirve para proporcionar una estructura clara y organizada para el desarrollo de sistemas de software. Ayuda a los desarrolladores a entender cómo los diferentes componentes del sistema interactúan entre sí, facilita la comunicación entre los miembros del equipo y asegura que el sistema cumpla con los requisitos funcionales y no funcionales. Además, una buena arquitectura puede mejorar la mantenibilidad, escalabilidad y rendimiento del software.

- Reducir la complejidad del sistema
    Estructurar el sistema en componentes manejables.
- Uniformidad
    Establecer estándares y convenciones para el desarrollo.
- Escalabilidad
    Permitir que el sistema crezca y se adapte a nuevas demandas.
- Mantenibilidad
    Facilitar las actualizaciones y modificaciones del sistema.
- Calidad de software
    Asegurar que el sistema cumpla con los requisitos de calidad.

---

## Tipos de Arquitectura

- Arquitectura Monolítica
    Todo el sistema se desarrolla como una única unidad. Es simple pero puede volverse difícil de mantener a medida que crece.
- Arquitectura en Capas (3-tier, N-tier)
    El sistema se divide en capas (presentación, lógica de negocio, datos) que interactúan entre sí. Ejemplo: MVC (Model-View-Controller).
- Hexagonal (Ports and Adapters)
    Separa el núcleo de la aplicación de las dependencias externas, facilitando las pruebas y la adaptabilidad.
    - Ports: Interfaces que definen cómo interactuar con el núcleo.
    - Adapters: Implementaciones concretas de los puertos para interactuar con el mundo exterior.
- Clean Architecture
    Similar a la arquitectura hexagonal, enfatiza la separación de responsabilidades y la independencia de los detalles de implementación.
    Pero con la distinción de capas concéntricas que definen la dirección de las dependencias.
- Microservicios
    El sistema se divide en servicios pequeños e independientes que se comunican entre sí a través de APIs. Cada servicio puede ser desarrollado, desplegado y escalado de manera independiente.

---

## Capas vs Componentes
- Capas
    Las capas son niveles de abstracción que agrupan funcionalidades similares. Cada capa tiene una responsabilidad específica y se comunica con las capas adyacentes.
    Ejemplo: Capa de presentación, capa de lógica de negocio, capa de datos.
- Componentes
    Los componentes son unidades funcionales dentro de una capa que realizan tareas específicas. Pueden ser clases, módulos o servicios.
    Ejemplo: Un componente de autenticación dentro de la capa de lógica de negocio.

Ejemplo:
- Capa de Presentación
    - Componente de Interfaz de Usuario
    - Componente de Validación de Entrada
- Capa de Data
    - Componente de Acceso a Base de Datos
    - Componente de Caché
- Capa de Dominio
    - Componente de Lógica de Negocio
    - Componente de Servicios de Dominio