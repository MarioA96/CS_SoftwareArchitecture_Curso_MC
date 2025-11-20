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

---

## Arquitecturas Limpias

Objetivo claro: Separar el código que cambia con frecuencia del código que es estable y central para el negocio.
Y este es de afuera hacia adentro. Los elementos de afuera conocan a los elementos de adentro, pero no al revés.

### Dominio

El dominio nunca se entera de herramientas exteriores.

- Entidades
    Representan los objetos del negocio con sus atributos y comportamientos.
- Servicios de Dominio
    Contienen la lógica de negocio que no pertenece a una entidad específica.
- Repositorios
    Interfaces para acceder a los datos del dominio.

### Aplicación

La capa de aplicación orquesta las operaciones del sistema, coordinando entre el dominio y las capas externas.
Orquesta funcionalidades sin contener lógica de negocio.

- Servicios de Aplicación
    Implementan los casos de uso, gestionando la lógica de flujo y las transacciones.
- Casos de Uso
    Definen las operaciones específicas que el sistema puede realizar.
- DTOs (Data Transfer Objects)
    Objetos simples para transferir datos entre capas.

### Infraestructura

La infraestructura proporciona implementaciones concretas para las interfaces definidas en las capas superiores. Facilita la interacción con sistemas externos y recursos técnicos.

Es la capa más cercana a los detalles técnicos y que interactua mas.

- Repositorios Concretos
    Implementaciones de los repositorios definidos en el dominio.
- Servicios Externos
    Integraciones con servicios externos como APIs, sistemas de mensajería, etc.
- Configuración
    Manejo de configuraciones y parámetros del sistema.

```Lecturas como la Arquitectura Limpia de Robert C. Martin (Uncle Bob) y patrones de diseño relacionados pueden proporcionar una comprensión más profunda de estos conceptos.

Este mismo sugiere una estructura como:
- Entidades (Enterprise Business Rules)
- Casos de Uso (Application Business Rules)
- Controllers/Gateways/Presenters (Interface Adapters)
- External Interfaces/DB/Devices/Web/UI (Frameworks and Drivers)

Se sugiere una capa intermedia entre Infraestructura y Aplicación llamada "Interface Adapters".
El cual es practicamente un transformador de entidades.

- Controladores
    Manejan la interacción con el usuario o sistemas externos.
- Presentadores
    Formatean los datos para la presentación.
- Gateways
    Adaptan las interfaces de los sistemas externos a las necesidades del dominio y la aplicación.
```