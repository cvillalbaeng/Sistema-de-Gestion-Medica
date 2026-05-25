using System;
using System.Collections.Generic;

namespace SistemaGestionMedica
{
    public class Clinica
    {
        // PROPIEDADES (Colecciones globales en memoria)
        public List<Paciente> Pacientes { get; set; }
        public List<Medico> Medicos { get; set; }
        public List<Cita> Citas { get; set; }

        // CONSTRUCTOR (Inicialización del sistema)
        public Clinica()
        {
            Pacientes = new List<Paciente>();
            Medicos = new List<Medico>();
            Citas = new List<Cita>();
        }

        // BLOQUE DE TRABAJO: INTEGRANTE 3
        // (Registros de Datos y Visualización Básica)
        public void RegistrarPaciente()
        {
            // Pendiente por desarrollar: Capturar datos del paciente por consola y validar que la cédula no esté duplicada en la lista (Requerimiento de Validación Cédula).
        }

        public void RegistrarMedico()
        {
            // Pendiente por desarrollar: Capturar datos del médico por consola y validar que el código de médico no esté duplicado en la lista (Requerimiento de Validación Código).
        }

        public void MostrarPacientes()
        {
            // Pendiente por desarrollar: Desplegar en pantalla la lista completa de pacientes registrados.
        }

        public void MostrarTodosLosMedicos()
        {
            // Pendiente por desarrollar: Desplegar en pantalla el catálogo completo de médicos de la clínica.
        }

        public void MostrarMedicosDisponibles()
        {
            // Pendiente por desarrollar: Filtrar la lista de médicos y mostrar solo aquellos cuya propiedad Disponible sea verdadera.
        }

        // BLOQUE DE TRABAJO: INTEGRANTE 4
        // (Flujo de Citas Médicas y Reglas de Negocio)
        public void AgendarCita(string cedula, string codigoMedico)
        {
            // Pendiente por desarrollar: Validar la existencia previa del paciente y del médico, y verificar que el médico esté disponible para agendar (Requerimientos de Agendamiento).
        }

        public void AtenderCita(string cedula, string codigoMedico)
        {
            // Pendiente por desarrollar: 
            // 1. Cambiar el estado de la cita seleccionada a 'Atendida = true' (Criterio de Aceptación 7).
            // 2. Registrar e incluir automáticamente al objeto Paciente dentro de la lista de pacientes atendidos del objeto Médico (Criterio de Aceptación 8).
        }

        public void MostrarCitasPendientes()
        {
            // Pendiente por desarrollar: Filtrar la lista global y desplegar únicamente las citas cuyo estado de atención sea falso.
        }

        public void MostrarHistorialCitas()
        {
            // Pendiente por desarrollar: Desplegar el reporte general con el histórico de todas las citas del sistema.
        }
    }
}