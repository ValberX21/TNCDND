using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace _5_JogoFrontEndWeb.Models
{
    public class HistoricoTentativas
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid IdHistoriTentativa { get; set; }

        public string IdJogo { get; set; }

        public string COD_JOGADOR { get; set; }

        public int NUM_TENTATIVA { get; set; }
        public int VALOR_TENTATIVA { get; set; }

        public DateTime DataHoraTentativa { get; set; }

        public string Resultado { get; set; }
    }
}
