using System.IO;
using System.Text.Json;
using spacePersonaje;
using spaceDragonBall;
using fabricaDePersonajes;
using spacePersistenciaDeDatos;
using spaceDirecciones;
using System.Threading.Tasks.Dataflow;
using implementaciones;
using spaceCombates;
using Microsoft.VisualBasic;


Implementacion.PantallaDeInicio();
ConsoleKeyInfo key;
do {
    Implementacion.Menu();
    key = Console.ReadKey(true); // Lee la tecla
    while ( key.KeyChar != '1' &&
            key.KeyChar != '2' && 
            key.KeyChar != '3' && 
            key.KeyChar != '4'){
        key = Console.ReadKey(true);
    }
    Console.Clear();


    switch (key.KeyChar)
    {
        case '1':
            Console.WriteLine("------------------ELEGIR PERSONAJE------------------");
            await Implementacion.cargarPersonajesAsync();
            Implementacion.MostrarPersonajes();
            int opcionPersonajes;
            
            do
            {
                int.TryParse(Console.ReadLine(), out opcionPersonajes);
                if(opcionPersonajes<1 || opcionPersonajes>10)
                {
                    Console.Write("Vegeta: !Acaso quieres romper el juego Insecto!, elige de nuevo: ");
                }
            } while (opcionPersonajes<1 || opcionPersonajes>10);
            System.Console.WriteLine(opcionPersonajes);
            //
            opcionPersonajes--;
            //Leo todos los personajes Jugables
            List<Personaje> PersonajesJugables = PersonajesJson.LeerPersonajes(Directorio.JsonPersonajes);
            int cantCombates = 1;

            
            do
            {
                System.Console.WriteLine("################### ENEMIGO {0} ###################",cantCombates);
                Personaje enemigo = await FabricaDePersonajes.PersonajeAleatorioAsync();
                string nomJ = PersonajesJugables[opcionPersonajes].Datos.Nombre;
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
            
                string textoIzquierda = nomJ;
                string textoDerecha = enemigo.Datos.Nombre;



                 //Obtener el ancho de la consola
                int anchoConsola = Console.WindowWidth;

                // Calcular la posición del texto en la 1/4 parte de la pantalla
                int posicionCuarto = anchoConsola / 4 - textoIzquierda.Length / 2;

                // Calcular la posición del texto en la 3/4 parte de la pantalla
                int posicionTresCuartos = (anchoConsola * 3 / 4) - textoDerecha.Length / 2;
                string nomIzquierdo="";
                string lineaTexto="";
                if (nomJ !="Zeno-Sama")
                {
                    nomIzquierdo= Implementacion.colorNombre(PersonajesJugables[opcionPersonajes]);
                
                    // Crear la línea con los dos textos centrados
                    lineaTexto = new string(' ', posicionCuarto) + textoIzquierda.ToUpper() 
                                    + new string(' ', posicionTresCuartos - posicionCuarto - nomIzquierdo.Length) ;
                    Console.Write(lineaTexto);        
                }else
                    {
                        lineaTexto = new string(' ', posicionCuarto) ;
                        Console.Write(lineaTexto);
                        nomIzquierdo = Implementacion.colorNombre(PersonajesJugables[opcionPersonajes]);
                        lineaTexto = new string(' ', posicionTresCuartos - posicionCuarto - nomIzquierdo.Length);
                        Console.Write(lineaTexto);
                    }
                // Verifica que el personaje de la derecha no sea un caso especial
                if (textoDerecha != "Zeno-Sama")
                {
                    textoDerecha= Implementacion.colorNombre(enemigo);
                    Console.Write($"{textoDerecha.ToUpper()}");
                }else{
                    textoDerecha = Implementacion.colorNombre(enemigo);
                }
                Console.Write("\n\n\n\n\n");
                Console.ResetColor();
                //Detener 
                Console.ReadKey();

        // Mostrar la línea de texto en la consola
            //----------------------------------------
            
                Combate.Combatir(PersonajesJugables[opcionPersonajes],enemigo);
                cantCombates++;
                Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
                Console.ReadKey();
            } while (cantCombates<=3 );
            if (PersonajesJugables[opcionPersonajes].Caracteristicas.Salud>0)
            {
                Console.WriteLine("Al final ganaste");
            }else
                {
                    Console.WriteLine("Perdiste mi ray");
                }
            Console.ReadKey();

        break;
        case '2':
            Console.WriteLine("opcion 2 swich");
        break;
        case '3':
            Console.WriteLine("opcion 3 swich");
        break;
    }
}while(key.KeyChar != '4');




    
    


        
    
        