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

        public IMongoCollection<HistoricoTentativas> HistoricoTentativas => _database.GetCollection<HistoricoTentativas>("HistoricoTentativas");
        public IMongoCollection<Jogador> Jogadores => _database.GetCollection<Jogador>("Jogadores"); 
    }
}
