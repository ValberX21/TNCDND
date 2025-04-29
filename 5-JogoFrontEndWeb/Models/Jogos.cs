using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace _5_JogoFrontEndWeb.Models
{
    public class Jogos
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid IdJogo { get; set; }
        public string IdJogador { get; set; }     
        public string RESULTADO_JOGO { get; set; }
        public string DIFICULDADE { get; set; }
        public DateTime DataHoraJogo { get; set; } = DateTime.Now;
    }
}
