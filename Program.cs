using System.IO;
using spaceDragonBall;
using System.Text.Json;


DragonBall dragonBall = await DragonBall.pruebaApiDragonBall();

foreach (var personaje in dragonBall.listaPersonajes)
{
    Console.WriteLine($"Nombre: {personaje.Name}");
    Console.WriteLine($"Ki: {personaje.Ki}");
    Console.WriteLine($"Raza: {personaje.Race}");
    Console.WriteLine($"Descripcion: {personaje.Description}");
    Console.WriteLine("");
}



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