using spaceDirecciones;
using spacePersistenciaDeDatos;
using System.Text.Json;
namespace spaceOpciones
{
    public class Opcion
    {
        private char dificultad;

        public char Dificultad { get => dificultad; set => dificultad = value; }

        public static Opcion leerOpciones()
        {
            Opcion opcion = new Opcion();
            if (!HistorialJson.Existe(Directorio.JsonOpciones))
            {
                opcion.dificultad = 'F'; 
                GuardarOpciones(opcion);
            }else{//Ya hay opciones guardadas enotces las lee
                string opcionesGuardadas = File.ReadAllText(Directorio.JsonOpciones);
                opcion = JsonSerializer.Deserialize<Opcion>(opcionesGuardadas);  
            }
            return opcion;
        }
        public static void GuardarOpciones(Opcion opciones)
        {
            string jsonD = JsonSerializer.Serialize(opciones); 
            File.WriteAllText(Directorio.JsonOpciones, jsonD);
        }

    }

    
}