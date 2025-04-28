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

        public DateTime DataHoraJgo { get; set; }

        public HistoricoTentativas historicoTentativas { get; set; } 
       
    }
}
