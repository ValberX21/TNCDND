using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace _5_JogoBackEnd.Models
{
    public class Jogos
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid IdJogo { get; set; }

        public string CodJogador { get; set; }        

        public string RESULTADO_JOGO { get; set; }
       
    }
}
