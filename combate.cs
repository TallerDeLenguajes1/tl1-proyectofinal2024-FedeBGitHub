
using spacePersonaje;

namespace spaceCombates
{
    public class Combate
    {
        public static void Combatir(Personaje p1, Personaje p2)
        {
            int turno = 1;
            Random aleatorio = new Random();
            int comienza = aleatorio.Next(0, 2); // 0-Comienza p1 | 1-Comienza p2

            while (p1.Caracteristicas.Salud>0 && p2.Caracteristicas.Salud>0)
            {
                ConsoleColor colorOriginal = Console.ForegroundColor;  
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("############## TURNO {0} ##############",turno);
                Console.ForegroundColor = colorOriginal;
                if (comienza==0)
                {
                    int danioProvocado = Combate.Atacar(p1,p2);
                    Combate.RecibirAtaque(p1, p2, danioProvocado);
                    comienza = 1;
                }else{
                    int danioProvocado = Combate.Atacar(p2,p1);
                    Combate.RecibirAtaque(p2, p1, danioProvocado);
                    comienza = 0;
                }
                
                Console.Write("\n");
                turno++;
            }
            Console.WriteLine(@"
                     _  __       ___  
                    | |/ /      / _ \ 
                    | ' <   _  | (_) |
                    |_|\_\ (_)  \___/ 
                ");
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