using _5_JogoBackEnd.Data;
using _5_JogoBackEnd.Models;
using MongoDB.Driver;

public static class HistoricoTentativasEndpoints
{
    public static void MaHistoricoTentativasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/historicoTentativas");

        group.MapPost("/create", async (HistoricoTentativas historicoTentativas, MongoDbContext db) =>
        {
            historicoTentativas.IdHistoriTentativa = Guid.NewGuid();
            
            await db.HistoricoTentativas.InsertOneAsync(historicoTentativas);
            return Results.Created($"/jogoNumero/{historicoTentativas.IdHistoriTentativa}", historicoTentativas);
        });

        group.MapGet("/listHistoricoTentativas/{jogoId:guid}", async (Guid jogoId, MongoDbContext db) => 
        {
            var jogos = await db.HistoricoTentativas
                .Find(hj => hj.IdJogo == jogoId.ToString())
                .ToListAsync();

            return Results.Ok(jogos);
        });

        
    }
}