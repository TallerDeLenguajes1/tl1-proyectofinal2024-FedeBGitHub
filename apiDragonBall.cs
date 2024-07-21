
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using spaceDirecciones;

namespace spaceDragonBall
{
    public class Items
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ki")]
        public string Ki { get; set; }

        [JsonPropertyName("maxKi")]
        public string MaxKi { get; set; }

        [JsonPropertyName("race")]
        public string Race { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("affiliation")]
        public string Affiliation { get; set; }

        [JsonPropertyName("deletedAt")]
        public object DeletedAt { get; set; }

    }

    public class Links
    {
        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }

    public class DragonBall
    {
        [JsonPropertyName("items")]
        public List<Items> listaPersonajes { get; set; }

        [JsonPropertyName("links")]
        public Links links { get; set; }

        public static async Task<DragonBall> GetApiDragonBallAsync()
        {
            var url = Directorio.ApiUrl;
            try
            {
                HttpClient clientP = new HttpClient();
                HttpResponseMessage respuesta = await clientP.GetAsync(url);
                respuesta.EnsureSuccessStatusCode();
                string respuestaBody = await respuesta.Content.ReadAsStringAsync();
                DragonBall dragonBall = JsonSerializer.Deserialize<DragonBall>(respuestaBody);

                //-----------Guardar los datos en un archivo Json-------------
                string direccion = "../../../DragonBall.json";
                File.WriteAllText(direccion,respuestaBody);
                return dragonBall;
            }
            catch (HttpRequestException a)
            {
                    Console.WriteLine("Problemas de acceso a la api");
                    Console.WriteLine("Mensaje: {0}" , a.Message);
                return null;
            }
        }
    }
}
    
