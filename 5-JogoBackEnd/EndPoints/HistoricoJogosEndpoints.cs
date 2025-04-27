using _5_JogoBackEnd.Data;
using _5_JogoBackEnd.Models;
using MongoDB.Driver;

public static class HistoricoJogosEndpoints
{
    public static void MapHistoricoJogosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/historicoJogos");

        group.MapPost("/create", async (HistoricoJogos historicoJogos, MongoDbContext db) =>
        {
            historicoJogos.IdJogo = Guid.NewGuid();
            
            await db.HistoricoJogos.InsertOneAsync(historicoJogos);
            return Results.Created($"/jogoNumero/{historicoJogos.IdJogo}", historicoJogos);
        });

        group.MapGet("/listJogosJogador/{jogadorId:guid}", async (Guid jogadorId, MongoDbContext db) => 
        {
            var jogos = await db.HistoricoJogos
                .Find(hj => hj.CodJogador == jogadorId.ToString())
                .ToListAsync();

            return Results.Ok(jogos);
        });

        
    }
}