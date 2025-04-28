using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _5_JogoFrontEndWeb.Models
{
    public class Jogador
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid IdJogador { get; set; }
        public string NomeJogador { get; set; }
    }
}
