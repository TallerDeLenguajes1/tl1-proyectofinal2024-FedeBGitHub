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
            await Implementacion.cargarPersonajesAsync();
            Implementacion.MostrarPersonajes();
            int opcionPersonajes;
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
            //Leo todos los personajes Jugables
            List<Personaje> PersonajesJugables = PersonajesJson.LeerPersonajes(Directorio.JsonPersonajes);
            int cantCombates = 1;
            bool sigue;
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
                cantCombates++;
                Console.Write("\n");
                Implementacion.PulsarParaContinuar("PULSE UNA TECLA PARA CONTINUAR2");
            } while (cantCombates<=3 && sigue==true);
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
            Console.WriteLine("opcion 3 swich");
            Console.ReadKey(true);
        break;
    }
}while(key.KeyChar != '4');




    
    


        
    
        