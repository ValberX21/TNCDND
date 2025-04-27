using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace _5_JogoBackEnd.Models
{
    public class HistoricoJogos
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid IdJogo { get; set; }

        public string CodJogador { get; set; }

        public int NumTentativa { get; set; }

        public DateTime DataHoraTentativa { get; set; }

        public string Resultado { get; set; } 

        public List<int> Tentativas { get; set; }
    }
}
