# Sistema de Gestión Médica

Este es un proyecto grupal desarrollado en C# como una aplicación de consola para la materia Programación 2. El sistema permite administrar el flujo básico de una clínica mediante el registro de pacientes, médicos y el control de citas médicas.

## 👥 Integrantes del Grupo
* Integrante 1: Clases Base (Paciente y Médico)
* Integrante 2: Clase Cita y Lógica de Fechas
* Integrante 3: Clase Clínica (Registros y Visualización)
* Integrante 4: Clase Clínica (Agendamiento) y Clase Program

## 🛠️ Funcionamiento del Sistema

El programa está estructurado en 5 clases principales que interactúan entre sí:

1. **Paciente:** Almacena los datos del paciente (Cédula, Nombre, Edad, Teléfono) y su lista de citas.
2. **Médico:** Almacena los datos del doctor (Código, Nombre, Especialidad, Disponibilidad) y la lista de personas que ha atendido.
3. **Cita:** Conecta a un paciente con un médico específico, guardando la fecha, el motivo de la consulta y si ya fue atendida.
4. **Clínica:** Es la clase principal que contiene las listas globales en memoria y ejecuta las acciones del sistema (registrar, agendar y listar).
5. **Program:** Contiene el método Main que arranca la aplicación y muestra el menú interactivo con las 10 opciones en consola.

## 📋 Requisitos Evaluados e Implementados

* **Validaciones:** El sistema valida que no se dupliquen cédulas de pacientes ni códigos de médicos, y verifica que los campos no se queden vacíos al escribir.
* **Reglas de Negocio:** Solo se pueden agendar citas con médicos que estén disponibles. Al atender una cita, el estado cambia automáticamente y el paciente pasa al historial del médico.
* **Datos Iniciales:** El programa genera datos de ejemplo automáticamente al iniciar para facilitar las pruebas.