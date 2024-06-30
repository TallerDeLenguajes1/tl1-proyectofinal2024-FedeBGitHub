/* //Como Inicializar una instancia de la clase "Personaje"
Personaje papas = new Personaje{
     Datos = new Datos{
        Nombre = "aaa",
        Raza = "ee",
        Descripcion = "sdasds",
    },
    Caracteristicas = new Caracteristicas{
        Salud = 100,
        Velocidad = 2,
        Destreza = 3,
        Fuerza = 4,
        Ki = 1,
        Resistencia = 8,
    }
};
*/

/*
//---------------------BORRADOR DE SISTEMA DE BACKUP---------------------
// creo un respaldo Json por si falla la conexion con la api
string direccion = "../../../DragonBall.json"; //Json principal
string json = File.ReadAllText(direccion); // Lo leo y guardo en esta variable
Console.WriteLine(json); 
string guardar = "../../../copia.json"; 
File.WriteAllText(guardar,json); // y hago el backup del Json principal/original

// deserealizo el json que habia convertido en string
DragonBall dragonBall = JsonSerializer.Deserialize<DragonBall>(json);

foreach (var personaje in dragonBall.items)
{
    Console.WriteLine($"Nombre: {personaje.name}");
    Console.WriteLine($"Ki: {personaje.ki}");
    Console.WriteLine($"Raza: {personaje.race}");
    Console.WriteLine($"Descripcion: {personaje.description}");
    Console.WriteLine("");
}
//---------------------------------------------------------------------------
*/

//---------------Crear un directorio en caso de no existir----------------
//string relativePath =@"datos\archivo.json";
        //string directory = Path.GetDirectoryName(relativePath);

       // if (!Directory.Exists(directory))
        //{
        //    Directory.CreateDirectory(directory);
        //}
        //File.WriteAllText(relativePath, respuestaBody);

        /*
        // Creo el directorio si no existe
            string directorio = Path.GetDirectoryName(nombreArchivo);
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        */

/*
//  GUARDADO DE PERSONAJES EN JSON 
Personaje prueba = new Personaje();
prueba = FabricaDePersonajes.PersonajeAleatorio(dragonBall);

//Quiero Hacer que si ya hay un personaje guardado entonces guarde agregandolo al Json (sin reemplazar el que ya estaba)
string nombreArchivo = "../../../personajeAleatorio.json";
string directorio = Path.GetDirectoryName(nombreArchivo);
if (!Directory.Exists(directorio))
{
    string jsonP = JsonSerializer.Serialize(prueba);
    string guardar = "../../../personajeAleatorio.json"; 
    File.WriteAllText(guardar,jsonP);
}else{
    Console.WriteLine("Ya hay un personaje guardado");
    //Leo el Json
    string JsonGuardado = File.ReadAllText(nombreArchivo);
    // Muestro por pantalla
    Console.WriteLine("Contenido del Json: "+JsonGuardado);
    // Serializo el personaje devuelto por la funcion FabricaDePersonajes
    string jsonP = JsonSerializer.Serialize(prueba);
    string NuevoJson = JsonGuardado+jsonP;
    File.WriteAllText(nombreArchivo,NuevoJson);
}
*/