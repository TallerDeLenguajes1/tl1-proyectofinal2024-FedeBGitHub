using System.Text.Json;
using System.Text.Json.Serialization;
using implementaciones;
using spaceDirecciones;
using spacePersonaje;


namespace spacePersistenciaDeDatos
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(800);
            Console.Write("\n\n");
            Implementacion.CentrarTextoHorizontal("¡ENTRASTE AL RANKING HISTORICO DE GANADORES!");
            Console.ResetColor();
            Console.WriteLine("\n\nLograste derrotar a todos los oponentes y convertirte en el guerrero más fuerte del universo , ahora vas a quedar en la historia como uno de los mejores peleadores \n\n");
            
            // Guardar los datos del personaje tanto Datos como Caracteristicas
            HistorialJson ganadorH = new HistorialJson();
            ganadorH.Ganador = personaje;
            ganadorH.Fecha = DateTime.Now;
            // Si gana un jugador guardar un nombre que el va a intruducir
            Thread.Sleep(1000);
            Console.Write("\nIngrese su nombre/apodo: ");
            ganadorH.NombreGanador = Console.ReadLine();

            List<HistorialJson> historial = new List<HistorialJson>();
             // Comprobar si la carpeta existe, si no, crearla
             
            if (!Directory.Exists(Directorio.CarpetaHistorial))
            {
                Directory.CreateDirectory(Directorio.CarpetaHistorial);
                Console.WriteLine("Carpeta creada");
            }
    
            if (!HistorialJson.Existe(direccionArchivo))
            {
                Console.WriteLine("Guardando Historial...");
                historial.Add(ganadorH); 
                string historialJson = JsonSerializer.Serialize(historial); 
                File.WriteAllText(direccionArchivo,historialJson);
            }else{
                    //Console.WriteLine("Ya hay al menos un personaje ganador guardado");
                    string historialGuardado = File.ReadAllText(direccionArchivo);
                    historial = JsonSerializer.Deserialize<List<HistorialJson>>(historialGuardado);
                    historial.Add(ganadorH);
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
        // Es el mismo metodo que tiene PersonajesJson, asi que no estaria reutilizando codigo CAMBIAR
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
