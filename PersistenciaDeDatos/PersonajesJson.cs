using System.Text.Json;
using spacePersonaje;


namespace espacioPersonajesJson
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
}