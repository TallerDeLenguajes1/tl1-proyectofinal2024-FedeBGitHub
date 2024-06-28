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
            personajeAleatorio.DatosP.Nombre = P.Name;
            personajeAleatorio.DatosP.Raza = P.Race;
            personajeAleatorio.DatosP.Descripcion = P.Description;

            personajeAleatorio.CaractP.Velocidad = random.Next(1, 10);
            personajeAleatorio.CaractP.Destreza = random.Next(1, 5);
            personajeAleatorio.CaractP.Fuerza = random.Next(1, 10);
            personajeAleatorio.CaractP.Ki = random.Next(1, 10);
            personajeAleatorio.CaractP.Resistencia = random.Next(1, 10);
            personajeAleatorio.CaractP.Salud = random.Next(1, 10);
            return personajeAleatorio;
        }

    }
}