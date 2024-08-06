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
using spaceOpciones;
using Microsoft.VisualBasic;


Opcion opciones = Opcion.leerOpciones();
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
            //Carga y Mustra de Personajes
            await Implementacion.cargarPersonajesAsync();
            Implementacion.MostrarPersonajes();
            int opcionPersonajes;
            //Elegir Personaje 
            Implementacion.CentrarTextoHorizontal("------------------ELEGIR PERSONAJE------------------");
            do
            {
                int.TryParse(Console.ReadLine(), out opcionPersonajes);
                if(opcionPersonajes<1 || opcionPersonajes>10)
                {
                    Console.Write("Vegeta: !Acaso quieres romper el juego Insecto!, elige de nuevo: ");
                }
            } while (opcionPersonajes<1 || opcionPersonajes>10);
            opcionPersonajes--;

            //Leer todos los personajes Jugables
            List<Personaje> PersonajesJugables = PersonajesJson.LeerPersonajes(Directorio.JsonPersonajes);

            int numCombate = 1;
            bool sigue;
            int cantCombates = 1;
            //Aplicar dificultad
            switch (opciones.Dificultad)
            {
                case 'F':
                    cantCombates = 5;
                break;
                case 'M':
                    cantCombates = 8;
                break;
                case 'D':
                    cantCombates = 10;
                break;
            }
            //----------------------------
            do
            {
                Personaje enemigo = await FabricaDePersonajes.PersonajeAleatorioAsync();
                Personaje personajeJugador = PersonajesJugables[opcionPersonajes];
            //----------------- Pantalla de versus -----------------
                Implementacion.PantallaVS(personajeJugador,enemigo);
                Console.Write("\n\n");
                Implementacion.PulsarParaContinuar("PULSE UNA TECLA PARA CONTINUAR");
            //----------------- Combate -----------------
                sigue = Combate.Combatir(PersonajesJugables[opcionPersonajes],enemigo);
                numCombate++;
                Console.Write("\n");
                Implementacion.PulsarParaContinuar("PULSE UNA TECLA PARA CONTINUAR2");
            } while (numCombate<=cantCombates && sigue==true);
            //----------------- Historial -----------------
            if (sigue==true)
            {
                Personaje ganador = PersonajesJugables[opcionPersonajes];
                HistorialJson.GuardarGanador(ganador,Directorio.JsonHistorial);
            }else
                {
                    Console.WriteLine("Perdiste mi ray");
                }
            Console.ReadKey(true);
            //Implementacion.PulsarParaContinuar("PRESIONE UNA TECLA PARA CONTINUAR");
        break;
        case '2':
            Implementacion.MostrarHistorial();
            Implementacion.PulsarParaContinuar("PULSE UNA TECLA PARA SALIR");
        break;
        case '3':
            Implementacion.Opcines();
            Implementacion.PulsarParaContinuar("PULSE UNA TECLA PARA SALIR");
        break;
    }
}while(key.KeyChar != '4');




    
    


        
    
        