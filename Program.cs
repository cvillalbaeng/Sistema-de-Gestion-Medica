using System;
using System.Collections.Generic;

namespace SistemaGestionMedica
{
    // =================================================================
    // EL MENÚ PRINCIPAL DEL SISTEMA ---> PARTE DEL INTEGRANTE 4.
    // =================================================================
    internal class Program
    {
        static void Main(string[] args)
        {
            // Seteamos la codificación universal para soportar emojis y caracteres especiales
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Instancia la clínica en memoria con las listas globales vacías
            Clinica miClinica = new Clinica();

            // 2. Control del bucle del menú
            bool programInExecution = true;

           while (programInExecution)
                {
                    Console.WriteLine("\n=======================================");
                    Console.WriteLine("    🏥  SISTEMA DE GESTIÓN MÉDICA  🏥   ");
                    Console.WriteLine("=======================================");
                    Console.WriteLine(" 1. 👤 Registrar Paciente"); // Esto lo debe desarrollar el Integrante 3:  
                    Console.WriteLine(" 2. 🥼 Registrar Médico");  // Esto lo debe desarrollar el Integrante 3: 
                    Console.WriteLine(" 3. 📋 Mostrar Lista de Pacientes"); // Esto lo debe desarrollar el Integrante 3: 
                    Console.WriteLine(" 4. 🗂️ Mostrar Todos los Médicos");  // Esto lo debe desarrollar el Integrante 3: 
                    Console.WriteLine(" 5. ✅ Mostrar Médicos Disponibles"); // Esto lo debe desarrollar el Integrante 3: 
                    Console.WriteLine(" 6. 📅 Agendar Cita"); //Int. 4. Listo 
                    Console.WriteLine(" 7. 🩺 Atender Cita");  //Int. 4. Listo
                    Console.WriteLine(" 8. ⏳ Mostrar Citas Pendientes"); //Int. 4. Listo
                    Console.WriteLine(" 9. 📜 Mostrar Historial General"); //Int. 4. Listo
                    Console.WriteLine("10. ❌ Salir del Sistema");
                    Console.Write("\n🔹 Seleccione una opción (1-10): ");

                string opcion = Console.ReadLine() ?? string.Empty;
                switch (opcion)
                {
                    case "1":
                        miClinica.RegistrarPaciente();
                        break;
                    case "2":
                        miClinica.RegistrarMedico();
                        break;
                    case "3":
                        miClinica.MostrarPacientes();
                        break;
                    case "4":
                        miClinica.MostrarTodosLosMedicos();
                        break;
                    case "5":
                        miClinica.MostrarMedicosDisponibles();
                        break;
                    case "6":
                        Console.Write("🔹 Ingrese la Cédula del Paciente: ");
                        string cedAgendar = Console.ReadLine() ?? string.Empty;
                        Console.Write("🔹 Ingrese el Código del Médico: ");
                        string medAgendar = Console.ReadLine() ?? string.Empty;

                        miClinica.AgendarCita(cedAgendar, medAgendar);
                        break;
                    case "7":
                        Console.Write("🔹 Ingrese la Cédula del Paciente: ");
                        string cedAtender = Console.ReadLine() ?? string.Empty;
                        Console.Write("🔹 Ingrese el Código del Médico: ");
                        string medAtender = Console.ReadLine() ?? string.Empty;

                        miClinica.AtenderCita(cedAtender, medAtender);
                        break;
                    case "8":
                        miClinica.MostrarCitasPendientes();
                        break;
                    case "9":
                        miClinica.MostrarHistorialCitas();
                        break;
                    case "10":
                        Console.WriteLine("\n👋 Saliendo del sistema... ¡Hasta luego!");
                        programInExecution = false;
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción inválida. Por favor, intente del 1 al 10.");
                        break;
                }
            }
        }
    }

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

        // =============================================================
        // INTEGRANTE 3 (Registros y Listas)
        // =============================================================
        public void RegistrarPaciente()
        {
            // INTEGRANTE 3: Desarrolla aquí la captura de datos del paciente por consola
        }

        public void RegistrarMedico()
        {
            // INTEGRANTE 3: Desarrolla aquí la captura de datos del médico por consola
        }

        public void MostrarPacientes()
        {
            // INTEGRANTE 3: Desarrolla aquí el despliegue de la lista completa de pacientes
        }

        public void MostrarTodosLosMedicos()
        {
            // INTEGRANTE 3: Desarrolla aquí el catálogo completo de médicos
        }

        public void MostrarMedicosDisponibles()
        {
            // INTEGRANTE 3: Desarrolla aquí el filtro de médicos disponibles == true
        }


        // =============================================================
        // LÓGICA DE CITAS Y NEGOCIO ---> Parte del INTEGRANTE 4 
        // =============================================================
        public void AgendarCita(string cedula, string codigoMedico)
        {
            Paciente pacienteEncontrado = null;
            foreach (var p in Pacientes)
            {
                if (p.Cedula == cedula)
                {
                    pacienteEncontrado = p;
                    break;
                }
            }

            if (pacienteEncontrado == null)
            {
                Console.WriteLine("🛑 Error: El paciente con la cédula ingresada no está registrado en el sistema.");
                return;
            }

            Medico medicoEncontrado = null;
            foreach (var m in Medicos)
            {
                if (m.CodigoMedico == codigoMedico)
                {
                    medicoEncontrado = m;
                    break;
                }
            }

            if (medicoEncontrado == null)
            {
                Console.WriteLine("🛑 Error: El médico con el código ingresado no existe en el sistema.");
                return;
            }

            if (medicoEncontrado.Disponible == false)
            {
                Console.WriteLine($"⚠️ Advertencia: El médico {medicoEncontrado.NombreCompleto} no está disponible en este momento.");
                return;
            }

            Cita nuevaCita = new Cita();
            nuevaCita.Codigo = "CIT-" + (Citas.Count + 1);
            nuevaCita.Paciente = pacienteEncontrado;
            nuevaCita.Medico = medicoEncontrado;
            nuevaCita.FechaCita = DateTime.Now;
            nuevaCita.Atendida = false;

            Citas.Add(nuevaCita);

            Console.WriteLine($"🎉 ¡Cita {nuevaCita.Codigo} agendada con éxito para el paciente {pacienteEncontrado.NombreCompleto} con el Dr. {medicoEncontrado.NombreCompleto}!");
        }

        public void AtenderCita(string cedula, string codigoMedico)
        {
            foreach (var cita in Citas)
            {
                if (cita.Paciente.Cedula == cedula && cita.Medico.CodigoMedico == codigoMedico && cita.Atendida == false)
                {
                    cita.Atendida = true;
                    cita.Medico.PacientesAtendidos.Add(cita.Paciente);

                    Console.WriteLine($"🎉 ¡La cita del paciente {cita.Paciente.NombreCompleto} con el Médico {cita.Medico.NombreCompleto} ha sido atendida con éxito! 🩺");
                    return;
                }
            }

            Console.WriteLine("🛑 Error: No se encontró ninguna cita pendiente que coincida con la cédula y el código del Médico ingresados.");
        }

        public void MostrarCitasPendientes()
        {
            if (Citas.Count == 0)
            {
                Console.WriteLine("ℹ️ Información: No hay citas registradas en el sistema.");
                return;
            }

            Console.WriteLine("\n=======================================");
            Console.WriteLine("    ⏳  CITAS PENDIENTES POR ATENDER   ");
            Console.WriteLine("=======================================");
            foreach (var cita in Citas)
            {
                if (cita.Atendida == false)
                {
                    Console.WriteLine($"🔹 Código: {cita.Codigo} | Paciente: {cita.Paciente.NombreCompleto} | Médico: {cita.Medico.NombreCompleto}");
                }
            }
        }

        public void MostrarHistorialCitas()
        {
            if (Citas.Count == 0)
            {
                Console.WriteLine("ℹ️ Información: No hay citas registradas en el sistema.");
                return;
            }

            Console.WriteLine("\n=======================================");
            Console.WriteLine("    📜  HISTORIAL GENERAL DE CITAS ");
            Console.WriteLine("=======================================");
            foreach (var cita in Citas)
            {
                string estadoEmoji = cita.Atendida ? "✅ Atendida" : "⏳ Pendiente";
                Console.WriteLine($"🔹 Código: {cita.Codigo} | Paciente: {cita.Paciente.NombreCompleto} | Médico: {cita.Medico.NombreCompleto} | Estado: {estadoEmoji}");
            }
        }
    }

    // =================================================================
    // INTEGRANTE 1 e INTEGRANTE 2 (Clases Base)
    // =================================================================
    public class Paciente
    {
        // INTEGRANTE 1: Desarrollar aquí propiedades completas, constructores y métodos de Paciente
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public List<Cita> HistorialCitas { get; set; } = new List<Cita>();
    }

    public class Medico
    {
        // INTEGRANTE 1: Desarrollar aquí propiedades completas, constructores y métodos de Médico
        public string CodigoMedico { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Specialidad { get; set; } = string.Empty;
        public bool Disponible { get; set; }
        public List<Paciente> PacientesAtendidos { get; set; } = new List<Paciente>();
    }

    public class Cita
    {
        // INTEGRANTE 2: Desarrollar aquí constructores y lógicas de fecha para la Cita
        public string Codigo { get; set; } = string.Empty;
        public Paciente Paciente { get; set; } = new Paciente();
        public Medico Medico { get; set; } = new Medico();
        public DateTime FechaCita { get; set; }
        public string MotivoConsulta { get; set; } = string.Empty;
        public bool Atendida { get; set; }
    }
}
