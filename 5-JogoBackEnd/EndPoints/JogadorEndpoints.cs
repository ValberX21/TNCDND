using _5_JogoBackEnd.Data;
using _5_JogoBackEnd.Models;
using MongoDB.Driver;

public static class JogadorEndpoints
{
    public static void MapJogadorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/jogadores");

        group.MapPost("/login", async (Jogador jogador, MongoDbContext db) =>
        {
            var DtJogador = await db.Jogadores
                .Find(j => j.NomeJogador == jogador.NomeJogador)
                .FirstOrDefaultAsync();

            if (DtJogador is null)
            {
                return Results.Json(new { message = "User not found." }, statusCode: StatusCodes.Status401Unauthorized);
            }

            var hashedInputPassword = PasswordHelper.HashPassword(jogador.Senha);

            if (DtJogador.Senha != hashedInputPassword)
            {
                return Results.Json(new { message = "Invalid password." }, statusCode: StatusCodes.Status401Unauthorized);
            }

            return Results.Ok(new { message = "Login successful!" });
        });

        group.MapPost("/create", async (Jogador jogador, MongoDbContext db) =>
        {
            jogador.IdJogador = Guid.NewGuid();
            jogador.Senha = PasswordHelper.HashPassword(jogador.Senha);

            await db.Jogadores.InsertOneAsync(jogador);
            return Results.Created($"/jogadores/{jogador.IdJogador}", jogador);
        });

        group.MapGet("/listJogadores", async ( MongoDbContext db) => 
        {
            var jogadoresCursor = await db.Jogadores.FindAsync(_ => true);
            var jogadores = await jogadoresCursor.ToListAsync();
            return Results.Ok(jogadores);
        });
    }
}

