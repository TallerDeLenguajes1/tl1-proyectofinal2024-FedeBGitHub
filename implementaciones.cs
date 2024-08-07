using spacePersonaje;
using spacePersistenciaDeDatos;
using spaceDirecciones;
using fabricaDePersonajes;
using System.Text.Json;
using System.Drawing;
using spaceOpciones;

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
            foreach (Personaje personaje in Personajes)
            {
                Console.WriteLine("------------------------- {0} -------------------------",cont);
                Console.Write("Nombre: ");
                Implementacion.colorNombre(personaje);
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
                //Thread.Sleep(1000);
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

            //Texto parpadeante
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
        public static void ParpadeoTexto(string texto)
        {
            while (!Console.KeyAvailable) // Continúa el bucle hasta que se presione una tecla
            {
                // Mostrar el texto
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(texto);
                
                // Esperar medio segundo (500 milisegundos)
                Thread.Sleep(800);

                // Borrar la línea anterior
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', texto.Length));

                // Esperar medio segundo antes de volver a mostrar el texto
                Thread.Sleep(800);
            }

            // Limpiar la entrada del teclado para evitar capturar la tecla presionada
            Console.ReadKey(true);
            Console.Write("\n");

        }
        public static void PulsarParaContinuar(string texto)
        {
            
            // Obtén el tamaño de la consola
            int consoleHeight = Console.WindowHeight;
            bool efecto = true;
            // Mueve el cursor a la posición inferior izquierda
            Console.SetCursorPosition(0, consoleHeight - 2);
            while (efecto) // Continúa el bucle hasta que se presione una tecla
            {
                // Mostrar el texto
                Console.SetCursorPosition(0, consoleHeight - 2);
                Console.Write(texto);
                
                // Esperar medio segundo (500 milisegundos)
                Thread.Sleep(800);

                // Borrar la línea anterior
                Console.SetCursorPosition(0, consoleHeight - 2);
                Console.Write(new string(' ', texto.Length));

                // Esperar medio segundo antes de volver a mostrar el texto
                Thread.Sleep(800);
                if (Console.KeyAvailable)
                {       
                    efecto = false; // Detener el parpadeo
                    Console.ReadKey(true); // Leer la tecla sin mostrarla
                    break;
                }
                Console.Write("\n");
            }
            // Limpiar la entrada del teclado para evitar capturar la tecla presionada
            Console.Write("\n");

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

        public static void colorNombre(Personaje p)
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
                        Console.ResetColor();
                        return;
                }else{
                    nombre = p.Datos.Nombre.ToUpper();
                }
                if(p.Datos.Raza=="Android" && p.Datos.Nombre=="Celula"){
                    nombre = "CELL";
                }
                Console.Write(nombre); 
                Console.ResetColor();
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
            Console.ResetColor();   
        }
        public static void PantallaVS (Personaje personajeJugador, Personaje enemigo)
        {
            string[] vs = new string[]
                    {
                        @"__      __   _____ ",
                        @"\ \    / /  / ____|",
                        @" \ \  / /  | (___  ",
                        @"  \ \/ /    \___ \ ",
                        @"   \  /     ____) |",
                        @"    \/     |_____/ "
                    };
            //------------------------------------------
                //Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                // Obtener el tamaño de la ventana de la consola
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                // Calcular el espacio necesario para centrar verticalmente
                int verticalPadding = (consoleHeight - vs.Length) / 2;

                // Imprimir líneas vacías antes del texto para centrar verticalmente
                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }

                // Imprimir cada línea del texto centrada horizontalmente
                foreach (string line in vs)
                {
                    // Calcular el espacio necesario para centrar horizontalmente
                    int horizontalPadding = (consoleWidth - line.Length) / 2;

                    // Imprimir espacios vacíos antes de la línea para centrar horizontalmente
                    Console.WriteLine(new string(' ', horizontalPadding) + line);
                }
            
                string textoIzquierda = personajeJugador.Datos.Nombre;
                string textoDerecha = enemigo.Datos.Nombre;


                 //Obtener el ancho de la consola
                int anchoConsola = Console.WindowWidth;

                // Calcular la posición del texto en la 1/4 parte de la pantalla
                int posicionCuarto = anchoConsola / 4 - textoIzquierda.Length / 2;

                // Calcular la posición del texto en la 3/4 parte de la pantalla
                int posicionTresCuartos = (anchoConsola * 3 / 4) - textoDerecha.Length / 2;
                
                //Verifica que el personaje de izquierda no sea un caso especial
                    string lineaTexto = new string(' ', posicionCuarto) ;
                    Console.Write(lineaTexto);
                    Implementacion.colorNombre(personajeJugador);
                if (personajeJugador.Datos.Nombre !="Zeno")
                {
                    lineaTexto = new string(' ', posicionTresCuartos - posicionCuarto - textoIzquierda.Length);      
                }else
                    {
                        string nomIzquierdo ="Zeno Sama";
                        lineaTexto = new string(' ', posicionTresCuartos - posicionCuarto - nomIzquierdo.Length);
                    }
                    Console.Write(lineaTexto);  
                // Muestra el personaje de la derecha
                    Implementacion.colorNombre(enemigo);
                
                Console.ResetColor();
        }
        public static void MostrarHistorial()
        {

            string[] ranking = new string[]
                    {
                        @" ____                    _      _                 ",
                        @"|  _ \    __ _   _ __   | | __ (_)  _ __     __ _ ",
                        @"| |_) |  / _` | | '_ \  | |/ / | | | '_ \   / _` |",
                        @"|  _ <  | (_| | | | | | |   <  | | | | | | | (_| |",
                        @"|_| \_\  \__,_| |_| |_| |_|\_\ |_| |_| |_|  \__, |",
                        @"                                            |___/ "
                    };
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string linea in ranking)
            {
                Implementacion.CentrarTextoHorizontal(linea);
            }
            Console.ResetColor();

            if (!Directory.Exists(Directorio.CarpetaHistorial) || 
                !HistorialJson.Existe(Directorio.JsonHistorial))
            {
                int consoleHeight = Console.WindowHeight;
                Console.SetCursorPosition(0, consoleHeight/2);
                Implementacion.CentrarTextoHorizontal("No hay historial");
            }else {
                Console.Write("\n\n\n");
                List<HistorialJson> Historiales = new List<HistorialJson>();
                // Leo lo que tengo en el Json
                string JsonHistorial = File.ReadAllText(Directorio.JsonHistorial);
                // Deserealizo en la lista de historiales
                Historiales = JsonSerializer.Deserialize<List<HistorialJson>>(JsonHistorial);
                foreach (HistorialJson historial in Historiales)
                {
                    Console.Write("Nombre: "+historial.NombreGanador+"      Fecha: "+historial.Fecha.ToString("d")+"        Hora: " + historial.Fecha.ToString("t"));
                    Console.Write("     Dificultad: ");
                    switch (historial.Dificultad)
                    {
                        case 'F':
                            Console.Write("Facil\n");
                        break;
                        case 'M':
                            Console.Write("Media\n");
                        break;
                        case 'D':
                            Console.Write("Dificil\n");
                        break;
                    }
                    Console.Write("Personaje Usado: ");
                    //Console.Write(historial.PersonajeGanador.Datos.Nombre);
                    Implementacion.colorNombre(historial.PersonajeGanador);
                    Console.Write("     Raza: ");
                    Implementacion.colorRaza(historial.PersonajeGanador);
                    
                    
                    Console.Write("\n");
                    int salud = historial.PersonajeGanador.Caracteristicas.Salud;
                    int ki = historial.PersonajeGanador.Caracteristicas.Ki;
                    int fuerza = historial.PersonajeGanador.Caracteristicas.Fuerza;
                    int velocidad = historial.PersonajeGanador.Caracteristicas.Velocidad;;
                    int destreza =historial.PersonajeGanador.Caracteristicas.Destreza;
                    int resistencia =historial.PersonajeGanador.Caracteristicas.Resistencia;
                    Console.WriteLine($"SALUD: {salud}    KI: {ki}    FUERZA: {fuerza}    VELOCIDAD: {velocidad}    DESTREZA:{destreza}    RESISTENCIA: {resistencia}");
                    
                    //Separar con guiones
                    int width = Console.WindowWidth; // Obtener el ancho de la consola
                    string line = new string('-', width); // Crear una cadena de guiones con el ancho de la consola

                    Console.WriteLine(line); // Imprimir la línea completa de guiones
                }
            }
        }
        public static void Opcines()
        {
            int elegir;
            do{
            string[] ranking = new string[]
                    {
                        @"  ___                   _                              ",
                        @" / _ \   _ __     ___  (_)   ___    _ __     ___   ___ ",
                        @"| | | | | '_ \   / __| | |  / _ \  | '_ \   / _ \ / __|",
                        @"| |_| | | |_) | | (__  | | | (_) | | | | | |  __/ \__ \",
                        @" \___/  | .__/   \___| |_|  \___/  |_| |_|  \___| |___/",
                        @"        |_|                                            "
                    };    
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string linea in ranking)
            {
                Implementacion.CentrarTextoHorizontal(linea);
            }

            Console.ResetColor();

            
            Opcion opciones = Opcion.leerOpciones();
            string[] stringOp = new string[]
                    {
                        @"Dificultad",
                        @"          ",
                        @"1 - Facil (5 Enemigos)   ",
                        @"2 - Medio (8 Enemigos)   ",
                        @"3 - Dificil (10 Enemigos)",
                        @"4 - Salir                ",
                    };    
        
            // Obtener el tamaño de la ventana de la consola
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                // Calcular el espacio necesario para centrar verticalmente
                int verticalPadding = (consoleHeight - stringOp.Length - ranking.Length -4) / 2;

                // Imprimir líneas vacías antes del texto para centrar verticalmente
                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }
            for (int i = 0; i < stringOp.Length; i++)
            {
                if (opciones.Dificultad=='F' && i==2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (opciones.Dificultad=='M' && i==3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (opciones.Dificultad=='D' && i==4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Implementacion.CentrarTextoHorizontal(stringOp[i]);
                Console.ResetColor();
            }

            do
            {
                int.TryParse(Console.ReadLine(), out elegir);
                if(elegir<1 || elegir>4)
                {
                    Console.Write("Elige una opcion valida: ");
                }
            } while (elegir<1 || elegir>4);
            if (elegir == 4)
            {
                return;
            }
            switch (elegir)
            {
                case 1:opciones.Dificultad='F';break;
                case 2:opciones.Dificultad='M';break;
                case 3:opciones.Dificultad='D';break;
            }
            Opcion.GuardarOpciones(opciones);
            Console.Clear();
        }while(elegir != 4);
        

        }

        
    }
}