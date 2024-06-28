
namespace spacePersonaje
{
    
    public class Personaje
    {
        private Datos datosP;
        private Caracteristicas caractP;
        internal Datos DatosP { get => datosP; set => datosP = value; }
        internal Caracteristicas CaractP { get => caractP; set => caractP = value; }
    }
    public class Datos
    {
        private string raza;
        private string nombre;
        private string descripcion;

        public string Raza { get => raza; set => raza = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        
    }

    public class Caracteristicas
    {
        private int velocidad; // 1 a 10
        private int destreza; // 1 a 5
        private int fuerza; // 1 a 10
        private int ki; // 1 a 10
        private int resistencia; // 1 a 10
        private int salud; // 100
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Ki { get => ki; set => ki = value; }
        public int Resistencia { get => resistencia; set => resistencia = value; }
        public int Salud { get => salud; set => salud = value; }
    }
}