using System.Text.Json;
using System.Text.Json.Serialization;
using spacePersonaje;


namespace espacioPersistenciaDeDatos
{
    public class PersonajesJson
    {
        public static void GuardarPersonajes (List<Personaje> personajes, string direccionArchivo)
        {
            // Serializo la lista de personajes en formato json
            string jsonP = JsonSerializer.Serialize(personajes);
            //Guardo el Json con el nombre pasado por parametro
            File.WriteAllText(direccionArchivo,jsonP);
        }
        public static List<Personaje> LeerPersonajes (string direccionArchivo)
        {
            List<Personaje> Personajes = new List<Personaje>();
            // Leo lo que tengo en el Json
            string JsonGuardado = File.ReadAllText(direccionArchivo);
            // Deserealizo
            Personajes = JsonSerializer.Deserialize<List<Personaje>>(JsonGuardado);
            return Personajes;
        }
        public static bool Existe (string direccionArchivo)
        {
            if (!File.Exists(direccionArchivo)) 
            {return false;}
            string contenido = File.ReadAllText(direccionArchivo);
            if (string.IsNullOrWhiteSpace(contenido)) 
            {return false;}
            return true;
        }
    }

    public class HistorialJson
    {
        private Personaje ganador;
        private DateTime fecha;
        private string nombreGanador;
        
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
        public Personaje Ganador { get => ganador; set => ganador = value; }

        public static void GuardarGanador(Personaje personaje, string direccionArchivo)
        {
            // Guardar los datos del personaje tanto Datos como Caracteristicas
            HistorialJson ganador = new HistorialJson();
            ganador.Ganador = personaje;
            ganador.Fecha = DateTime.Now;
            // Si gana un jugador guardar un nombre que el va a intruducir
            Console.Write("Ingrese su nombre/apodo para el historial: ");
            ganador.NombreGanador = Console.ReadLine();
            // Si gana la computadora aclaro que gano la consola

            List<HistorialJson> historial = new List<HistorialJson>();
            
            if (!File.Exists(direccionArchivo))
            {
                Console.WriteLine("No hay historial");
                historial.Add(ganador); 
                string historialJson = JsonSerializer.Serialize(historial); 
                File.WriteAllText(direccionArchivo,historialJson);
            }else{
                Console.WriteLine("Ya hay al menos un personaje ganador guardado");
                string historialGuardado = File.ReadAllText(direccionArchivo);
                historial = JsonSerializer.Deserialize<List<HistorialJson>>(historialGuardado);
                historial.Add(ganador);
                string jsonP = JsonSerializer.Serialize(historial);
                File.WriteAllText(direccionArchivo,jsonP);
            }
        }
        public static List<HistorialJson> LeerGanadores (string direccionArchivo)
        {
            List<HistorialJson> Ganadores = new List<HistorialJson>();
            // Leo lo que tengo en el Json
            string JsonGuardado = File.ReadAllText(direccionArchivo);
            // Deserealizo en la lista Ganadores
            Ganadores = JsonSerializer.Deserialize<List<HistorialJson>>(JsonGuardado);
            return Ganadores;
        }
        public static bool Existe (string direccionArchivo)
        {
            if (!File.Exists(direccionArchivo)) 
            {return false;}
            string contenido = File.ReadAllText(direccionArchivo);
            if (string.IsNullOrWhiteSpace(contenido)) 
            {return false;}
            return true;
        }
        
    }
}