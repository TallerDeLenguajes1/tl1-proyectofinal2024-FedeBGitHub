

class Personaje
{
    private Datos datosP;
    private Caracteristicas caractP;
    internal Datos DatosP { get => datosP; set => datosP = value; }
    internal Caracteristicas CaractP { get => caractP; set => caractP = value; }
}
class Datos
{
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fecNac;
    private int edad;

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FecNac { get => fecNac; set => fecNac = value; }
    public int Edad { get => edad; set => edad = value; }
}

class Caracteristicas
{
    private int velocidad; // 1 a 10
    private int destreza; // 1 a 5
    private int fuerza; // 1 a 10
    private int nivel; // 1 a 10
    private int armadura; // 1 a 10
    private int salud; // 100
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    
}