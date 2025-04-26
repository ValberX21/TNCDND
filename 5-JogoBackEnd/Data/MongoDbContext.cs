using _5_JogoBackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace _5_JogoBackEnd.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<HistoricoJogos> HistoricoJogos => _database.GetCollection<HistoricoJogos>("HistoricoJogos");
        public IMongoCollection<HistoricoJogos> Jogador => _database.GetCollection<HistoricoJogos>("Jogador");
    }
}
