
using implementaciones;
using spacePersonaje;

namespace spaceCombates
{
    public class Combate
    {
        public static bool Combatir(Personaje Jugador, Personaje Enemigo)
        {
            InfoEnemigo(Enemigo);
            bool ganador= true;
            int turno = 1;
            Random aleatorio = new Random();
            int comienza = aleatorio.Next(0, 2); // 0-Comienza Jugador | 1-Comienza Enemigo

            while (Jugador.Caracteristicas.Salud>0 && Enemigo.Caracteristicas.Salud>0)
            {
                ConsoleColor colorOriginal = Console.ForegroundColor;  
                Console.ForegroundColor = ConsoleColor.Blue;
                string texto = $"TURNO {turno}";
                Implementacion.CentrarTextoHorizontal(texto);
                Console.ForegroundColor = colorOriginal;
                if (comienza==0)
                {
                    Thread.Sleep(400);
                    string[] peleaOpciones = new string[]
                    {
                        @" ________________________",
                        @"|        Opciones        |",
                        @"|1 - Atacar              |",
                        @"|2 - Semilla del ermitaño|",
                        @"|_______________________ |",
                        @"                          ",
                    };
                    foreach (string linea in peleaOpciones)
                    {
                        Implementacion.CentrarTextoHorizontal(linea);
                    }
                    ConsoleKeyInfo key;
                    key = Console.ReadKey(true); 
                    while ( key.KeyChar != '1' && key.KeyChar != '2')
                    {
                        key = Console.ReadKey(true);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(Jugador) ");
                    Console.ResetColor();
                    switch (key.KeyChar)
                    {
                        case '1':
                            int danioProvocado = Combate.Atacar(Jugador,Enemigo);
                            Combate.RecibirAtaque(Jugador, Enemigo, danioProvocado);
                        break;
                        case '2':
                            Console.WriteLine("");
                            int curar = 15;
                            if (Jugador.Caracteristicas.Salud>85)
                            {
                                curar = 100 - Jugador.Caracteristicas.Salud;
                            }
                            Implementacion.colorNombre(Jugador);
                            Console.Write($" Come una Semilla del Ermitaño ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"+ {curar} Puntos de vida");
                            Console.ResetColor();
                            Jugador.Caracteristicas.Salud += curar;
                            Console.Write($" , Salud: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{Jugador.Caracteristicas.Salud}\n");
                            Console.ResetColor();
                        break;
                    }
                    
                    comienza = 1;
                }else{
                    Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(Enemigo) ");
                    Console.ResetColor();
                    // ELECCION ENEMIGO
                    if (Enemigo.Caracteristicas.Salud<=85)
                    {
                        Random random = new Random();
                        int AtacarOCurar = random.Next(1,3);
                        switch (AtacarOCurar)
                        {
                            case 1: //ATACA
                                int danioProvocado = Combate.Atacar(Enemigo,Jugador);
                                Combate.RecibirAtaque(Enemigo, Jugador, danioProvocado);
                            break;
                            case 2: //SE CURA
                                Console.WriteLine("");
                                int curar = 15;
                                Implementacion.colorNombre(Enemigo);
                                Console.Write($" Come una Semilla del Ermitaño ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"+ {curar} puntos de vida");
                                Console.ResetColor();
                                Enemigo.Caracteristicas.Salud += curar;
                                Console.Write($" , Salud: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"{Enemigo.Caracteristicas.Salud}\n");
                                Console.ResetColor();
                                
                            break;
                        }
                    }else{
                        int danioProvocado = Combate.Atacar(Enemigo,Jugador);
                        Combate.RecibirAtaque(Enemigo, Jugador, danioProvocado);
                    }
                    
                    comienza = 0;
                }
                Console.Write("\n");
                
                turno++;
            }

            string[] victoria = new string[]
                    {
                        @"                  ",
                        @" _  __       ___  ",
                        @"| |/ /      / _ \ ",
                        @"| ' <   _  | (_) |",
                        @"|_|\_\ (_)  \___/ ",
                        
                    };
            string[] derrota = new string[]
                    {
                        @" ____                      _        ",
                        @"|  _ \  ___ _ __ _ __ ___ | |_ __ _ ",
                        @"| | | |/ _ \ '__| '__/ _ \| __/ _` |",
                        @"| |_| |  __/ |  | | | (_) | || (_| |",
                        @"|____/ \___|_|  |_|  \___/ \__\__,_|",
                        
                    };
                
            if (Jugador.Caracteristicas.Salud>0)
            {
                int curar = 100 - Jugador.Caracteristicas.Salud;
                Console.Write($"Salud = {Jugador.Caracteristicas.Salud} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" + {curar} \n");
                Jugador.Caracteristicas.Salud += curar;
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Imprimir cada línea del texto centrada horizontalmente
                foreach (string lineaV in victoria)
                {
                    Implementacion.CentrarTextoHorizontal(lineaV);
                }
                ganador = true;
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string lineaD in derrota)
                {
                    Implementacion.CentrarTextoHorizontal(lineaD);
                }
                ganador = false;
            }
            Console.ResetColor();
            return ganador;
        }
        public static int Atacar(Personaje atacante, Personaje defensor)
        {
            // Atacante
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Ki;
            Random aleatorio = new Random();
            int efectividad = aleatorio.Next(0, 101);
            const int cteAjuste = 500;
            // Defensor
            int defensa = defensor.Caracteristicas.Resistencia * defensor.Caracteristicas.Velocidad;
            // Daño
            int danioProvocado = ((ataque * efectividad) - defensa) / cteAjuste;
            System.Console.WriteLine("EFECTIVIDAD:{0}",efectividad);
            return danioProvocado;
        }
        public static void RecibirAtaque(Personaje atacante, Personaje defensor,int danio)
        {
            defensor.Caracteristicas.Salud -= danio;
            if (defensor.Caracteristicas.Salud < 0)
            {
                defensor.Caracteristicas.Salud = 0;
            } 
            Implementacion.colorNombre(atacante);
            Console.Write($" ataca a {defensor.Datos.Nombre} causa un daño total de {danio} puntos, Salud {defensor.Datos.Nombre}:  {defensor.Caracteristicas.Salud}\n");
        }
        public static void InfoEnemigo (Personaje enemigo)
        {
                Implementacion.CentrarTextoHorizontal("Datos Del Enemigo");
                Console.Write("Nombre: ");
                Implementacion.colorNombre(enemigo);
                Console.Write("     Raza: ");
                // Aplico color a la raza
                Implementacion.colorRaza(enemigo);
                Console.Write("\n");
                int salud = enemigo.Caracteristicas.Salud;
                int ki = enemigo.Caracteristicas.Ki;
                int fuerza = enemigo.Caracteristicas.Fuerza;
                int velocidad = enemigo.Caracteristicas.Velocidad;
                int destreza =enemigo.Caracteristicas.Destreza;
                int resistencia =enemigo.Caracteristicas.Resistencia;
                Console.WriteLine($"SALUD: {salud}    KI: {ki}    FUERZA: {fuerza}    VELOCIDAD: {velocidad}    DESTREZA:{destreza}    RESISTENCIA: {resistencia}");
                Console.Write("\n");
                Implementacion.ParpadeoTexto("PULSE UNA TECLA PARA COMENZAR EL COMBATE");
        }
    }
}