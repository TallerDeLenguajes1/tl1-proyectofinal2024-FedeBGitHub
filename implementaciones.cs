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
                        Personajes.Add(await FabricaDePersonajes.PersonajeAleatorioAsync());
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
                    Personajes.Add(await FabricaDePersonajes.PersonajeAleatorioAsync());
                    Console.WriteLine("-----------{0}-----------",cont);
                    cont++;
                }
                // Guardo todos los personajes agregados
                PersonajesJson.GuardarPersonajes(Personajes,Directorio.JsonPersonajes);
            }
        }
        public static void MostrarPersonajes()
        {
            List<Personaje> Personajes = PersonajesJson.LeerPersonajes(Directorio.JsonPersonajes);
            //Guardar color original
            ConsoleColor colorOriginal = Console.ForegroundColor;
            int cont = 1;
            foreach (Personaje personaje in Personajes)
            {
                Console.WriteLine("--------------- {0} ---------------",cont);
                Console.Write("Nombre: ");
                switch (personaje.Datos.Raza)
                {
                    case "Human":
                        Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                    case "God":
                        Console.ForegroundColor = ConsoleColor.White;
                    break;
                    case "Saiyan":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                    case "Namekian":
                        Console.ForegroundColor = ConsoleColor.Green;
                    break;
                    case "Android":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "Nucleico benigno":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                    case "Nucleico":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                    case "Angel":
                        Console.ForegroundColor = ConsoleColor.Gray; 
                    break;
                    case "Jiren Race":
                        Console.ForegroundColor = ConsoleColor.Red; 
                    break;
                    case "Evil janemba":
                        Console.ForegroundColor = ConsoleColor.Magenta; 
                    break;
                    case "Frieza Race":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                    case "Majin":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                }
                if (personaje.Datos.Raza=="Unknown")
                {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Z");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("E");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("N");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("A");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("M");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("A");
                }else if(personaje.Datos.Raza=="Android" && personaje.Datos.Nombre=="Celula"){
                    Console.Write("CELL");
                }else{
                    Console.Write(personaje.Datos.Nombre.ToUpper());
                }
                Console.Write("\n");
                // Restaurar el color de texto original
                Console.ForegroundColor = colorOriginal;
                Console.Write("Raza: ");
                
                switch (personaje.Datos.Raza)
                {
                    case "Human":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Humano");
                    break;
                    case "God":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Dios");
                    break;
                    case "Saiyan":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Saiyajin");
                    break;
                    
                    case "Namekian":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Namekuseijin");
                    break;
                    case "Android":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Androide");
                        Console.ForegroundColor = colorOriginal;
                    break;
                    case "Nucleico benigno":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("Nucleico benigno");
                        
                    break;
                    case "Nucleico":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("Nucleico");
                    break;
                    case "Angel":
                        Console.ForegroundColor = ConsoleColor.Gray; 
                        Console.Write("Angel");
                    break;
                    case "Jiren Race":
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.Write("Raza de Jiren");
                    break;
                    case "Evil janemba":
                        Console.ForegroundColor = ConsoleColor.Magenta; 
                        Console.Write("Demonio");
                    break;
                    case "Frieza Race":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Raza de Freezer");
                    break;
                    case "Majin":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Mounstruo");
                    break;
                    case "Unknown":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("m");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("i");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("s");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("c");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("i");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("e");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("t");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("e");
                    break;        
                }
                // Restaurar el color de texto original
                Console.ForegroundColor = colorOriginal;
                Console.WriteLine("\nDescripción: {0}",personaje.Datos.Descripcion);
                int salud = personaje.Caracteristicas.Salud;
                int ki = personaje.Caracteristicas.Ki;
                int fuerza = personaje.Caracteristicas.Fuerza;
                int velocidad = personaje.Caracteristicas.Velocidad;;
                int destreza =personaje.Caracteristicas.Destreza;
                int resistencia =personaje.Caracteristicas.Resistencia;
                Console.WriteLine($"SALUD: {salud}    KI: {ki}    FUERZA: {fuerza}    VELOCIDAD: {velocidad}    DESTREZA:{destreza}    RESISTENCIA: {resistencia}");
                cont++;
                Console.Write("\n");
                //Console.WriteLine("---------------------------------");
                
            }
            
        }
        
    }
}