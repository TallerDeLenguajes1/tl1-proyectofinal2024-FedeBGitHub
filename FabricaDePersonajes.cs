using spaceDragonBall;
using spacePersonaje;


namespace fabricaDePersonajes
{
    class FabricaDePersonajes
    {
        private static Random random = new Random();
    
        public static async Task<DragonBall> GetDragonBallAsync()
        {
            DragonBall result = await GetDragonBallAsync();
            return result;
        }
        
        public static Personaje PersonajeAleatorio(DragonBall contenidoApi)
        {
            
            //Traigo todo el contenido de la api (dentro estan los personajes)
            //DragonBall contenidoApi = await GetDragonBallAsync();
            //Traigo un personaje aleatorio y lo guardo
            Items P = contenidoApi.listaPersonajes[random.Next(0, 58)]; //Items es una subclase de DragonBall
            //Paso los datos relevantes
            Personaje personajeAleatorio = new Personaje();
            personajeAleatorio.Datos = new Datos();
            personajeAleatorio.Caracteristicas = new Caracteristicas();
            personajeAleatorio.Datos.Nombre = P.Name;
            personajeAleatorio.Datos.Raza = P.Race;
            personajeAleatorio.Datos.Descripcion = P.Description;

            personajeAleatorio.Caracteristicas.Velocidad = random.Next(1, 10);
            personajeAleatorio.Caracteristicas.Destreza = random.Next(1, 5);
            personajeAleatorio.Caracteristicas.Fuerza = random.Next(1, 10);
            personajeAleatorio.Caracteristicas.Ki = random.Next(1, 10);
            personajeAleatorio.Caracteristicas.Resistencia = random.Next(1, 10);
            personajeAleatorio.Caracteristicas.Salud = 100;
            return personajeAleatorio;
        }

    }
}