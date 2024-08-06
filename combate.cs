
using implementaciones;
using spacePersonaje;

namespace spaceCombates
{
    public class Combate
    {
        public static bool Combatir(Personaje Jugador, Personaje Enemigo)
        {
            bool ganador= true;
            int turno = 1;
            Random aleatorio = new Random();
            int comienza = aleatorio.Next(0, 2); // 0-Comienza p1 | 1-Comienza p2

            while (Jugador.Caracteristicas.Salud>0 && Enemigo.Caracteristicas.Salud>0)
            {
                ConsoleColor colorOriginal = Console.ForegroundColor;  
                Console.ForegroundColor = ConsoleColor.Blue;
                string texto = $"############## TURNO {turno} ##############";
                Implementacion.CentrarTextoHorizontal(texto);
                //Console.WriteLine("############## TURNO {0} ##############",turno);
                Console.ForegroundColor = colorOriginal;
                if (comienza==0)
                {
                    int danioProvocado = Combate.Atacar(Jugador,Enemigo);
                    Combate.RecibirAtaque(Jugador, Enemigo, danioProvocado);
                    comienza = 1;
                }else{
                    int danioProvocado = Combate.Atacar(Enemigo,Jugador);
                    Combate.RecibirAtaque(Enemigo, Jugador, danioProvocado);
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
            
                
                //Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                // Obtener el tamaño de la ventana de la consola
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                // Calcular el espacio necesario para centrar verticalmente
                int verticalPadding = (consoleHeight - derrota.Length) / 2;

                // Imprimir líneas vacías antes del texto para centrar verticalmente
                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }

                
            if (Jugador.Caracteristicas.Salud>0)
            {
                Jugador.Caracteristicas.Salud += 100;
                Console.Write($"Salud = {Jugador.Caracteristicas.Salud} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"+ 100 \n");
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
            int defensa = atacante.Caracteristicas.Resistencia * atacante.Caracteristicas.Velocidad;
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
            Console.WriteLine($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} causa un daño total de {danio} puntos, Salud {defensor.Datos.Nombre}:  {defensor.Caracteristicas.Salud}");
        }

    }

    
}