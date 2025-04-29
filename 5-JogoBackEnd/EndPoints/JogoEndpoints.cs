using _5_JogoBackEnd.Data;
using _5_JogoBackEnd.Models;
using MongoDB.Driver;

namespace _5_JogoBackEnd.EndPoints
{
    public static class JogoEndpoints
    {
        public static void MapJogos(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/jogos");

            group.MapPost("/create", async (Jogos jogo, MongoDbContext db) =>
            {
                await db.Jogos.InsertOneAsync(jogo);
                return Results.Created($"/jogo/{jogo.IdJogo}", jogo);
            });

            group.MapGet("/listjogos/{jogadorId:guid}", async (Guid jogadorId, MongoDbContext db) =>
            {
                var jogos = await db.Jogos
                    .Find(hj => hj.IdJogador == jogadorId)
                    .ToListAsync();

                return Results.Ok(jogos);
            });
        }
    }
}
