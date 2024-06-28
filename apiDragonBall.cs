
using System;
using System.Text.Json.Serialization;

namespace spaceDragonBall
{
    public class PersonajeD
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
        public List<PersonajeD> listaPersonajes { get; set; }

        [JsonPropertyName("links")]
        public Links links { get; set; }
    }

}
    
