using System;
using System.Collections.Generic;

namespace SistemaGestionMedica
{
    // =================================================================
    // EL MENÚ PRINCIPAL DEL SISTEMA ---> PARTE DEL INTEGRANTE 4 (TÚ)
    // =================================================================
    internal class Program
    {
        static void Main(string[] args)
        {
            // Codificación universal para soportar emojis y caracteres especiales
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Instancia la clínica en memoria con las listas globales precargadas (CA-10)
            Clinica miClinica = new Clinica();

            // 2. Control del bucle del menú (CA-17)
            bool programInExecution = true;

            while (programInExecution)
            {
                Console.WriteLine("\n=======================================");
                Console.WriteLine("    🏥  SISTEMA DE GESTIÓN MÉDICA  🏥   ");
                Console.WriteLine("=======================================");
                Console.WriteLine(" 1. 👤 Registrar Paciente");
                Console.WriteLine(" 2. 🥼 Registrar Médico");
                Console.WriteLine(" 3. 📋 Mostrar Lista de Pacientes");
                Console.WriteLine(" 4. 🗂️ Mostrar Todos los Médicos");
                Console.WriteLine(" 5. ✅ Mostrar Médicos Disponibles");
                Console.WriteLine(" 6. 📅 Agendar Cita");
                Console.WriteLine(" 7. 🩺 Atender Cita (Con Diagnóstico)");
                Console.WriteLine(" 8. ⏳ Mostrar Citas Pendientes");
                Console.WriteLine(" 9. 📜 Mostrar Historial General de Citas");
                Console.WriteLine("10. 📊 Mostrar Estadísticas del Sistema");
                Console.WriteLine("11. 🔍 Módulo de Búsquedas Avanzadas (EXTRAS)");
                Console.WriteLine("12. ❌ Salir del Sistema");
                Console.Write("\n🔹 Seleccione una opción (1-12): ");

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
                        miClinica.MostrarEstadisticas();
                        break;
                    case "11":
                        miClinica.MenuBusquedas();
                        break;
                    case "12":
                        Console.WriteLine("\n👋 Saliendo del sistema... ¡Hasta luego!");
                        programInExecution = false;
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción inválida. Por favor, intente del 1 al 12.");
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

        // CONSTRUCTOR (CA-10: Inicialización con datos de ejemplo automáticos)
        public Clinica()
        {
            Pacientes = new List<Paciente>();
            Medicos = new List<Medico>();
            Citas = new List<Cita>();

            // Datos de prueba precargados para facilitar la evaluación del profesor
            Paciente p1 = new Paciente("123", "Jose Lopez", 38, "0412-1112233");
            Paciente p2 = new Paciente("456", "Pedro Perez", 25, "0414-4445566");
            Pacientes.Add(p1);
            Pacientes.Add(p2);

            Medico m1 = new Medico("MED-01", "Dr. Pedro Ramirez", "Cardiología");
            Medico m2 = new Medico("MED-02", "Dr. Luis Gomez", "Pediatría");
            m2.Disponible = false;
            Medicos.Add(m1);
            Medicos.Add(m2);

            // Cita de ejemplo precargada
            Cita citaEjemplo = new Cita(p1, m1, DateTime.Now, "Control preventivo");
            citaEjemplo.Codigo = "CIT-1";
            Citas.Add(citaEjemplo);
            p1.HistorialCitas.Add(citaEjemplo);
        }

        // =============================================================
        // INTEGRANTE 3: MÉTODOS DE REGISTRO Y VISUALIZACIÓN
        // =============================================================
        public void RegistrarPaciente()
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("          👤 REGISTRAR PACIENTE        ");
            Console.WriteLine("=======================================");

            Console.Write("🔹 Ingrese la Cédula: ");
            string cedulaInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(cedulaInput))
            {
                Console.WriteLine("🛑 Error: La cédula es un campo obligatorio.");
                return;
            }

            foreach (var pacienteExistente in Pacientes)
            {
                if (pacienteExistente.Cedula.Trim() == cedulaInput.Trim())
                {
                    Console.WriteLine("🛑 Error: Ya existe un paciente registrado con esa misma cédula.");
                    return;
                }
            }

            Console.Write("🔹 Ingrese el Nombre Completo: ");
            string nombreInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nombreInput))
            {
                Console.WriteLine("🛑 Error: El nombre completo no puede estar vacío.");
                return;
            }

            Console.Write("🔹 Ingrese la Edad: ");
            string edadInput = Console.ReadLine() ?? string.Empty;
            int edadConvertida;
            bool esNumeroValido = int.TryParse(edadInput, out edadConvertida);

            if (!esNumeroValido || edadConvertida <= 0)
            {
                Console.WriteLine("🛑 Error: Debe ingresar una edad numérica válida (mayor a cero).");
                return;
            }

            Console.Write("🔹 Ingrese el Número de Teléfono: ");
            string telefonoInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(telefonoInput))
            {
                Console.WriteLine("🛑 Error: El teléfono de contacto es obligatorio.");
                return;
            }

            Paciente nuevoPaciente = new Paciente(cedulaInput, nombreInput, edadConvertida, telefonoInput);
            Pacientes.Add(nuevoPaciente);

            Console.WriteLine($"\n🎉 ¡Éxito! El paciente '{nombreInput}' ha sido registrado correctamente.");
        }

        public void RegistrarMedico()
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("           🥼 REGISTRAR MÉDICO          ");
            Console.WriteLine("=======================================");

            Console.Write("🔹 Ingrese el Código Único del Médico: ");
            string codigoInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(codigoInput))
            {
                Console.WriteLine("🛑 Error: El código del médico no puede estar en blanco.");
                return;
            }

            foreach (var medicoExistente in Medicos)
            {
                if (medicoExistente.CodigoMedico.Trim() == codigoInput.Trim())
                {
                    Console.WriteLine("🛑 Error: Ese código ya le pertenece a otro médico en el sistema.");
                    return;
                }
            }

            Console.Write("🔹 Ingrese el Nombre Completo del Médico: ");
            string nombreInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nombreInput))
            {
                Console.WriteLine("🛑 Error: El nombre del médico es requerido.");
                return;
            }

            Console.Write("🔹 Ingrese la Especialidad Médica: ");
            string especialidadInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(especialidadInput))
            {
                Console.WriteLine("🛑 Error: Debe especificar una especialidad.");
                return;
            }

            Medico nuevoMedico = new Medico(codigoInput, nombreInput, especialidadInput);
            Medicos.Add(nuevoMedico);

            Console.WriteLine($"\n🎉 ¡Éxito! El Dr(a). '{nombreInput}' se integró al sistema correctamente.");
        }

        public void MostrarPacientes()
        {
            if (Pacientes.Count == 0)
            {
                Console.WriteLine("ℹ️ No hay pacientes registrados en el sistema actualmente.");
                return;
            }

            Console.WriteLine("\n=========================================================");
            Console.WriteLine("             👤 LISTA DE PACIENTES REGISTRADOS            ");
            Console.WriteLine("=========================================================");

            foreach (var paciente in Pacientes)
            {
                paciente.MostrarInformacion();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void MostrarTodosLosMedicos()
        {
            if (Medicos.Count == 0)
            {
                Console.WriteLine("ℹ️ No hay médicos registrados en el sistema actualmente.");
                return;
            }

            Console.WriteLine("\n=========================================================");
            Console.WriteLine("              🗂️ CATÁLOGO GENERAL DE MÉDICOS             ");
            Console.WriteLine("=========================================================");

            foreach (var medico in Medicos)
            {
                medico.MostrarInformacion();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void MostrarMedicosDisponibles()
        {
            if (Medicos.Count == 0)
            {
                Console.WriteLine("ℹ️ No hay médicos registrados en el sistema.");
                return;
            }

            Console.WriteLine("\n=========================================================");
            Console.WriteLine("             ✅ PERSONAL MÉDICO DISPONIBLE               ");
            Console.WriteLine("=========================================================");

            int medicosDisponiblesContados = 0;

            foreach (var medico in Medicos)
            {
                if (medico.Disponible == true)
                {
                    medico.MostrarInformacion();
                    Console.WriteLine("---------------------------------------------------------");
                    medicosDisponiblesContados++;
                }
            }

            if (medicosDisponiblesContados == 0)
            {
                Console.WriteLine("ℹ️ Alerta: Todos los médicos se encuentran ocupados o no disponibles.");
            }
        }

        // =============================================================
        // LÓGICA DE CITAS Y NEGOCIO ---> INTEGRANTE 4 (TÚ)
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

            // EXTRA-3: Validar límite de máximo 3 citas por médico al día
            int citasDelMedicoHoy = 0;
            DateTime hoy = DateTime.Today;
            foreach (var cita in Citas)
            {
                if (cita.Medico.CodigoMedico == codigoMedico && cita.FechaCita.Date == hoy)
                {
                    citasDelMedicoHoy++;
                }
            }

            if (citasDelMedicoHoy >= 3)
            {
                Console.WriteLine($"🛑 Error: El Dr. {medicoEncontrado.NombreCompleto} ya alcanzó el límite máximo de 3 citas agendadas por el día de hoy.");
                return;
            }

            Cita nuevaCita = new Cita();
            nuevaCita.Codigo = "CIT-" + (Citas.Count + 1);
            nuevaCita.Paciente = pacienteEncontrado;
            nuevaCita.Medico = medicoEncontrado;
            nuevaCita.FechaCita = DateTime.Now;
            nuevaCita.Atendida = false;

            Citas.Add(nuevaCita);
            pacienteEncontrado.HistorialCitas.Add(nuevaCita);

            Console.WriteLine($"🎉 ¡Cita {nuevaCita.Codigo} agendada con éxito para el paciente {pacienteEncontrado.NombreCompleto} con el Dr. {medicoEncontrado.NombreCompleto}!");
        }

        public void AtenderCita(string cedula, string codigoMedico)
        {
            foreach (var cita in Citas)
            {
                if (cita.Paciente.Cedula == cedula && cita.Medico.CodigoMedico == codigoMedico && cita.Atendida == false)
                {
                    // EXTRA-4: Adición de Diagnóstico Médico obligatorio por consola
                    Console.WriteLine($"\n📋 Atendiendo a: {cita.Paciente.NombreCompleto} con el Dr. {cita.Medico.NombreCompleto}");
                    Console.Write("🔹 Ingrese el diagnóstico médico del paciente: ");
                    string diagnosticoInput = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(diagnosticoInput))
                    {
                        diagnosticoInput = "Consulta general completada sin observaciones críticas.";
                    }

                    cita.MotivoConsulta = diagnosticoInput;
                    cita.Atendida = true;
                    cita.Medico.PacientesAtendidos.Add(cita.Paciente);

                    Console.WriteLine($"🎉 ¡La cita del paciente {cita.Paciente.NombreCompleto} ha sido atendida con éxito! 🩺");
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
            int pendientesContadas = 0;
            foreach (var cita in Citas)
            {
                if (cita.Atendida == false)
                {
                    Console.WriteLine($"🔹 Código: {cita.Codigo} | Paciente: {cita.Paciente.NombreCompleto} | Médico: {cita.Medico.NombreCompleto}");
                    pendientesContadas++;
                }
            }

            if (pendientesContadas == 0)
            {
                Console.WriteLine("ℹ️ Excelente: No quedan citas pendientes por atender.");
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
            Console.WriteLine("    📜  HISTORIAL GENERAL DE CITAS     ");
            Console.WriteLine("=======================================");
            foreach (var cita in Citas)
            {
                string estadoEmoji = cita.Atendida ? "✅ Atendida" : "⏳ Pendiente";
                Console.WriteLine($"🔹 Código: {cita.Codigo} | Paciente: {cita.Paciente.NombreCompleto} | Médico: {cita.Medico.NombreCompleto} | Estado: {estadoEmoji}");
                if (cita.Atendida)
                {
                    Console.WriteLine($"   📝 Diagnóstico: {cita.MotivoConsulta}");
                }
            }
        }

        // EXTRA-6: Módulo de Estadísticas Globales del Sistema
        public void MostrarEstadisticas()
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("      📊 ESTADÍSTICAS DEL SISTEMA      ");
            Console.WriteLine("=======================================");
            Console.WriteLine($"👤 Total de Pacientes Registrados: {Pacientes.Count}");
            Console.WriteLine($"🥼 Total de Personal Médico: {Medicos.Count}");
            Console.WriteLine($"📅 Volumen Total de Citas Manejadas: {Citas.Count}");

            int atendidas = 0;
            foreach (var c in Citas) if (c.Atendida) atendidas++;
            Console.WriteLine($"   ✅ Citas Atendidas: {atendidas}");
            Console.WriteLine($"   ⏳ Citas en Espera: {Citas.Count - atendidas}");
            Console.WriteLine("=======================================");
        }

        // =============================================================
        // 🌟 SUB-MENÚ EXTRAS: MÓDULO DE BÚSQUEDAS AVANZADAS
        // =============================================================
        public void MenuBusquedas()
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("       🔍 CONSULTAS Y BÚSQUEDAS        ");
            Console.WriteLine("=======================================");
            Console.WriteLine(" 1. Buscar Paciente (Por Nombre/Cédula) [EXTRA-1]");
            Console.WriteLine(" 2. Buscar Médico por Especialidad      [EXTRA-2]");
            Console.WriteLine(" 3. Ver Historial Médico de un Paciente [EXTRA-5]");
            Console.WriteLine(" 4. Buscar Cita (Por Código/Paciente)   [EXTRA-7]");
            Console.WriteLine(" 5. Volver al Menú Principal");
            Console.Write("\n🔹 Seleccione una opción de búsqueda (1-5): ");

            string subOpcion = Console.ReadLine() ?? string.Empty;
            switch (subOpcion)
            {
                case "1":
                    Console.Write("🔹 Ingrese el Nombre o Cédula a buscar: ");
                    string criterioP = Console.ReadLine() ?? string.Empty;
                    bool pEncontrado = false;
                    foreach (var p in Pacientes)
                    {
                        if (p.Cedula.Contains(criterioP) || p.NombreCompleto.ToLower().Contains(criterioP.ToLower()))
                        {
                            p.MostrarInformacion();
                            pEncontrado = true;
                        }
                    }
                    if (!pEncontrado) Console.WriteLine("ℹ️ No se encontraron pacientes que coincidan con la búsqueda.");
                    break;

                case "2":
                    Console.Write("🔹 Ingrese la Especialidad a buscar: ");
                    string criterioE = Console.ReadLine() ?? string.Empty;
                    bool mEncontrado = false;
                    foreach (var m in Medicos)
                    {
                        if (m.Especialidad.ToLower().Contains(criterioE.ToLower()))
                        {
                            m.MostrarInformacion();
                            mEncontrado = true;
                        }
                    }
                    if (!mEncontrado) Console.WriteLine("ℹ️ No se encontraron médicos en esa especialidad.");
                    break;

                case "3":
                    Console.Write("🔹 Ingrese la Cédula del Paciente: ");
                    string cedHistorial = Console.ReadLine() ?? string.Empty;
                    Paciente pacHist = null;
                    foreach (var p in Pacientes) if (p.Cedula == cedHistorial) pacHist = p;

                    if (pacHist == null)
                    {
                        Console.WriteLine("🛑 Error: El paciente no existe.");
                        return;
                    }

                    Console.WriteLine($"\n📜 HISTORIAL CLÍNICO DE: {pacHist.NombreCompleto}");
                    if (pacHist.HistorialCitas.Count == 0) Console.WriteLine("   No registra consultas previas.");
                    foreach (var cita in pacHist.HistorialCitas)
                    {
                        string est = cita.Atendida ? "✅ Atendida" : "⏳ Pendiente";
                        Console.WriteLine($"   - Cita {cita.Codigo} | Dr. {cita.Medico.NombreCompleto} | Estado: {est}");
                        if (cita.Atendida) Console.WriteLine($"     Diagnóstico: {cita.MotivoConsulta}");
                    }
                    break;

                case "4":
                    Console.Write("🔹 Ingrese el Código de la Cita o Nombre del Paciente: ");
                    string criterioC = Console.ReadLine() ?? string.Empty;
                    bool citEncontrada = false;
                    foreach (var cita in Citas)
                    {
                        if (cita.Codigo.ToLower().Contains(criterioC.ToLower()) || cita.Paciente.NombreCompleto.ToLower().Contains(criterioC.ToLower()))
                        {
                            cita.MostrarInformacion();
                            citEncontrada = true;
                        }
                    }
                    if (!citEncontrada) Console.WriteLine("ℹ️ No se encontraron citas bajo ese criterio.");
                    break;

                default:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        }
    }

    // =================================================================
    // INTEGRANTE 1: CLASES PACIENTE Y MÉDICO (Propiedades Automáticas Básicas)
    // =================================================================
    public class Paciente
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public List<Cita> HistorialCitas { get; set; }

        public Paciente()
        {
            Cedula = string.Empty;
            NombreCompleto = string.Empty;
            Telefono = string.Empty;
            HistorialCitas = new List<Cita>();
        }

        public Paciente(string cedula, string nombre, int edad, string telefono)
        {
            Cedula = cedula;
            NombreCompleto = nombre;
            Edad = edad;
            Telefono = telefono;
            HistorialCitas = new List<Cita>();
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"🔹 Paciente: {NombreCompleto} | C.I: {Cedula} | Edad: {Edad} | Tel: {Telefono}");
        }
    }

    public class Medico
    {
        public string CodigoMedico { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }
        public List<Paciente> PacientesAtendidos { get; set; }

        public Medico()
        {
            CodigoMedico = string.Empty;
            NombreCompleto = string.Empty;
            Especialidad = string.Empty;
            PacientesAtendidos = new List<Paciente>();
        }

        public Medico(string codigo, string nombre, string especialidad)
        {
            CodigoMedico = codigo;
            NombreCompleto = nombre;
            Especialidad = especialidad;
            Disponible = true;
            PacientesAtendidos = new List<Paciente>();
        }

        public void MostrarInformacion()
        {
            string estado = Disponible ? "✅ Disponible" : "❌ Ocupado";
            Console.WriteLine($"🥼 Dr(a). {NombreCompleto} | Código: {CodigoMedico} | Esp: {Especialidad} | {estado}");
        }
    }

    // =================================================================
    // INTEGRANTE 2: CLASE CITA (Rescatada, encapsulada y corregida)
    // =================================================================
    public class Cita
    {
        private string _codigo = string.Empty;
        private Paciente _paciente = new Paciente();
        private Medico _medico = new Medico();
        private DateTime _fechaCita;
        private string _motivoConsulta = string.Empty;
        private bool _atendida;

        public string Codigo
        {
            get => _codigo;
            set => _codigo = value;
        }
        public Paciente Paciente
        {
            get => _paciente;
            set => _paciente = value;
        }
        public Medico Medico
        {
            get => _medico;
            set => _medico = value;
        }
        public DateTime FechaCita
        {
            get => _fechaCita;
            set => _fechaCita = value;
        }
        public string MotivoConsulta
        {
            get => _motivoConsulta;
            set => _motivoConsulta = value;
        }
        public bool Atendida
        {
            get => _atendida;
            set => _atendida = value;
        }

        public Cita()
        {
            _fechaCita = DateTime.Now;
            _atendida = false;
        }

        public Cita(Paciente paciente, Medico medico, DateTime fechaCita, string motivoConsulta)
        {
            _paciente = paciente;
            _medico = medico;
            _fechaCita = fechaCita;
            _motivoConsulta = motivoConsulta;
            _atendida = false;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"🔹 Cita Código: {Codigo} | Estado: {(Atendida ? "✅ Atendida" : "⏳ Pendiente")}");
            Console.WriteLine($"📅 Fecha: {FechaCita:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"👤 Paciente: {Paciente.NombreCompleto} (Cédula: {Paciente.Cedula})");
            Console.WriteLine($"🥼 Médico: {Medico.NombreCompleto} (Especialidad: {Medico.Especialidad})");
            Console.WriteLine($"📝 Motivo/Diagnóstico: {(string.IsNullOrEmpty(MotivoConsulta) ? "No especificado" : MotivoConsulta)}");
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}