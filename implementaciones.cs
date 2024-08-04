using spacePersonaje;
using spacePersistenciaDeDatos;
using spaceDirecciones;
using fabricaDePersonajes;

namespace implementaciones
{
    class Implementacion
    {
        public static async Task cargarPersonajesAsync()
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
            string nom;
            foreach (Personaje personaje in Personajes)
            {
                Console.WriteLine("------------------------- {0} -------------------------",cont);
                Console.Write("Nombre: ");
                // Aplico el color al nombre
                nom = Implementacion.colorNombre(personaje);
                if (personaje.Datos.Nombre != "Zeno")
                {
                    Console.Write(nom);
                }
                Console.Write("\n");
                
                // Restaurar el color de texto original
                Console.ForegroundColor = colorOriginal;
                Console.Write("Raza: ");
                // Aplico color a la raza
                Implementacion.colorRaza(personaje);
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
                Thread.Sleep(1000);
            }
        }
        public static void PantallaDeInicio()
        {
            //Guardar color original
            ConsoleColor colorOriginal = Console.ForegroundColor;
            // Arreglo de cadenas
            string[] titulo = new string[]
            {
                @$"    ____                             ",
                @$"    ____        ____   _____",
                @$"   / __ \_________  ____  ____  ____ ",
                @$"   / __ )____ _/ / /  /__  /",
                @$"  / / / / ___/ __ `/ __ `/ __ \/ __ \",
                @$"  / __  / __ `/ / /     / / ",
                @$" / /_/ / /  / /_/ / /_/ / /_/ / / / /",
                @$" / /_/ / /_/ / / /     / /__",
                @$"/_____/_/   \__,_/\__, /\____/_/ /_/ ",
                @$"/_____/\__,_/_/_/     /____/",
                @$"              /____/              ",
                @$"                                           "

            };
        
            // Obtener el tamaño de la ventana de la consola
            int screenWidth = Console.WindowWidth;
            int screenHeight = Console.WindowHeight;

            // Limpiar la pantalla
            Console.Clear();

            // Calcular la posición vertical para centrar
            int verticalStart = (screenHeight - titulo.Length) / 2;

            int cont=0;
            // Iterar sobre cada linea y calcular la posición centrada
            for (int i = 0; i < titulo.Length; i = i +2)
            {
                    // Calcular el espacio a la izquierda para la primera línea
                int firstLeftPadding = (screenWidth / 2) - titulo[i].Length;

                // Calcular el espacio a la izquierda para la segunda línea
                int secondLeftPadding = screenWidth / 2;
                // Mover el cursor a la posición calculada para la primera línea y escribirla
            Console.SetCursorPosition(firstLeftPadding, verticalStart + cont);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(titulo[i]);
            Thread.Sleep(200);

            // Mover el cursor a la posición calculada para las siguientes lineas
            Console.SetCursorPosition(secondLeftPadding, verticalStart + cont);
            if ((i+1) < titulo.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{titulo[i+1]}\n");
                Thread.Sleep(200);
            }
            cont++;
            }
            Console.ForegroundColor = colorOriginal;

            string text = "Presiona cualquier tecla para continuar...";
            int horizontal = (screenWidth - text.Length) / 2;
            TextoParpadeante(horizontal,verticalStart,cont);
            
            //Implementacion.Menu2(verticalStart,cont);
        }

        static void TextoParpadeante(int horizontal, int verticalStart, int Nlinea)
        {
            int cont = Nlinea;
            string text = "Presiona cualquier tecla para continuar...";
            bool efecto = true;

                // Crea un nuevo hilo para detectar entradas de teclado
            while (efecto)
            {
                Console.SetCursorPosition(horizontal, verticalStart + cont + 3);
                Console.Write(text);
                Thread.Sleep(700); 

                Console.SetCursorPosition(horizontal, verticalStart + cont + 3);
                Console.Write(new string(' ', text.Length));
                Thread.Sleep(700); 

                if (Console.KeyAvailable)
                {       
                    efecto = false; // Detener el parpadeo
                    Console.ReadKey(true); // Leer la tecla sin mostrarla
                    break;
                }
            }
        }
        public static void CentrarTextoHorizontal(string texto)
        {
            int anchoConsola = Console.WindowWidth;
            // Calcular el número de espacios a la izquierda para centrar el texto
            int espaciosIzquierda = (anchoConsola - texto.Length) / 2;
            // Crear una cadena con espacios y el texto
            string textoCentrado = new string(' ', espaciosIzquierda) + texto;
            // Mostrar el texto centrado
            Console.Write($"{textoCentrado}\n");
        }
        public static void Menu()
        {
            Thread.Sleep(500);
            //Guardar color original
            ConsoleColor colorOriginal = Console.ForegroundColor;
            // Arreglo de cadenas
            string[] titulo = new string[]
            {
                @$"    ____                             ",
                @$"    ____        ____   _____",
                @$"   / __ \_________  ____  ____  ____ ",
                @$"   / __ )____ _/ / /  /__  /",
                @$"  / / / / ___/ __ `/ __ `/ __ \/ __ \",
                @$"  / __  / __ `/ / /     / / ",
                @$" / /_/ / /  / /_/ / /_/ / /_/ / / / /",
                @$" / /_/ / /_/ / / /     / /__",
                @$"/_____/_/   \__,_/\__, /\____/_/ /_/ ",
                @$"/_____/\__,_/_/_/     /____/",
                @$"              /____/              ",
                @$"                                           "

            };
        
            // Obtener el tamaño de la ventana de la consola
            int screenWidth = Console.WindowWidth;
            int screenHeight = Console.WindowHeight;

            // Limpiar la pantalla
            Console.Clear();

            // Calcular la posición vertical para centrar
            int verticalStart = (screenHeight - titulo.Length) / 2;

            int cont=0;
            // Iterar sobre cada linea y calcular la posición centrada
            for (int i = 0; i < titulo.Length; i = i +2)
            {
                    // Calcular el espacio a la izquierda para la primera línea
                int firstLeftPadding = (screenWidth / 2) - titulo[i].Length;

                // Calcular el espacio a la izquierda para la segunda línea
                int secondLeftPadding = screenWidth / 2;
                // Mover el cursor a la posición calculada para la primera línea y escribirla
            Console.SetCursorPosition(firstLeftPadding, verticalStart + cont);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(titulo[i]);

            // Mover el cursor a la posición calculada para la segunda línea y escribirla
            Console.SetCursorPosition(secondLeftPadding, verticalStart + cont);
            if ((i+1) < titulo.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{titulo[i+1]}\n");
            }
            cont++;
            }
            Console.ForegroundColor = colorOriginal;
            string[] opciones = new string[]
            {
                "¡Comienza la batalla!",
                "1 - Iniciar Juego    ",
                "2 - Ranking Historico",
                "3 - Opciones         ",
                "4 - Salir            "
            };
            
            cont = cont + 3;
            
            for (int j = 0; j < opciones.Length; j++)
            {
                
                int horizontal = (screenWidth - opciones[j].Length) / 2;
                Console.SetCursorPosition(horizontal, verticalStart + cont);
                Console.WriteLine(opciones[j]);
                if (j==0)
                {
                   cont++; 
                }
                cont++;
            }
        }
        public static void Menu2(int verticalStart, int cont)
        {
            int screenWidth = Console.WindowWidth;
            int i = cont;
            string[] opciones = new string[]
            {
                "¡Comienza la batalla!",
                "1 - Iniciar Juego    ",
                "2 - Ranking Historico",
                "3 - Opciones         ",
                "4 - Salir            "
            };
            
            i = i + 3;
            
            for (int j = 0; j < opciones.Length; j++)
            {
                
                int horizontal = (screenWidth - opciones[j].Length) / 2;
                Console.SetCursorPosition(horizontal, verticalStart + i);
                Console.WriteLine(opciones[j]);
                if (j==0)
                {
                   i++; 
                }
                i++;
            }
        }

        public static string colorNombre(Personaje p)
        {
            string nombre = "null";
            switch (p.Datos.Raza)
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
                if (p.Datos.Raza=="Unknown")
                { 
                        nombre = "Zeno Sama";
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
                }else{
                    nombre = p.Datos.Nombre.ToUpper();
                }
                if(p.Datos.Raza=="Android" && p.Datos.Nombre=="Celula"){
                    nombre = "CELL";
                }
                return nombre; 
        }
        public static void colorRaza(Personaje p)
        {
            switch (p.Datos.Raza)
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
        }
    }
}