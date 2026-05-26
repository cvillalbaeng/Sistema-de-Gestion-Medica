# Sistema de Gestión Médica

Este es un proyecto grupal desarrollado en C# como una aplicación de consola para la materia Programación 2. El sistema permite administrar de forma sencilla el flujo básico de una clínica mediante el registro de pacientes, médicos y el control de citas médicas.

## 👥 Integrantes del Grupo y Tareas

- **Integrante 1:** Desarrollo de las clases de molde principales (`Paciente` y `Médico`).
- **Integrante 2:** Desarrollo de la clase `Cita` y el control de sus datos internos.
- **Integrante 3:** Métodos para registrar y mostrar las listas de pacientes y médicos en la clínica.
- **Integrante 4:** Diseño del menú principal interactivo y los métodos para agendar, atender y reportar citas.

## 🛠️ Funcionamiento del Sistema

El programa está estructurado en 5 clases que trabajan en equipo:

1. **Paciente:** Guarda los datos personales (Cédula, Nombre, Edad, Teléfono) y su lista de consultas.
2. **Médico:** Guarda los datos del doctor (Código, Nombre, Especialidad, Disponibilidad) y la lista de pacientes que ha atendido.
3. **Cita:** Une a un paciente con un médico, guardando la fecha, el diagnóstico y si ya fue atendido.
4. **Clínica:** Es el motor del programa. Contiene las listas generales en la memoria de la computadora y ejecuta las acciones de registro, agendamiento y búsquedas.
5. **Program:** Contiene el arranque del programa y muestra el menú en pantalla.

## 📋 Características Implementadas (Criterios de Evaluación)

- **Menú Completo e Interactivo:** El sistema cuenta con un menú de 12 opciones organizadas con emojis para que sea muy fácil y cómodo de usar en la consola.
- **Validaciones de Seguridad:** El programa no permite registrar campos vacíos, ni tampoco que existan dos pacientes con la misma cédula o dos médicos con el mismo código.
- **Reglas de la Clínica:** Solo se pueden agendar citas con médicos que estén disponibles en el sistema. Además, se limitó el sistema a un máximo de 3 citas al día por médico para no sobrecargarlos.
- **Atención con Diagnóstico:** Al marcar una cita como atendida, el sistema solicita obligatoriamente el diagnóstico médico, cambia el estado de la cita y guarda al paciente en el récord del doctor.
- **Carga de Datos Automática:** Para que las pruebas sean más rápidas, el programa inicia con pacientes, médicos y citas de ejemplo ya cargados desde el primer segundo.
- **Módulo de Búsquedas Avanzadas:** Se incluyó una sección especial para buscar pacientes por nombre/cédula, médicos por su especialidad e historiales clínicos completos.
