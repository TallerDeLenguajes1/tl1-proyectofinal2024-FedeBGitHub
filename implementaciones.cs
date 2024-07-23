using spacePersonaje;
using spacePersistenciaDeDatos;
using spaceDirecciones;
using fabricaDePersonajes;

namespace implementaciones
{
    class Implementacion
    {
        public static async Task cargarPersonajes()
        {
            List<Personaje> Personajes;
            if (PersonajesJson.Existe(Directorio.JsonPersonajes))
            {
                Personajes = PersonajesJson.LeerPersonajes(Directorio.JsonPersonajes);
                if (Personajes.Count < 10)
                {
                    // Si hay menos de 10 personajes, entonces agrego los faltantes
                    while (Personajes.Count<10)
                    {
                        Personajes.Add(await FabricaDePersonajes.PersonajeAleatorio());
                    }
                    // Guardo todos los personajes agregados
                    PersonajesJson.GuardarPersonajes(Personajes,Directorio.JsonPersonajes);
                }
            } else{
                Console.WriteLine("Cargando...");
                int cont=1;
                Personajes = new List<Personaje>();
                while (Personajes.Count<10)
                {
                    Personajes.Add(await FabricaDePersonajes.PersonajeAleatorio());
                    Console.WriteLine("-----------{0}-----------",cont);
                    cont++;
                }
                // Guardo todos los personajes agregados
                PersonajesJson.GuardarPersonajes(Personajes,Directorio.JsonPersonajes);
            }
        }
    }
}