using _5_JogoFrontEndWeb.Components;
using _5_JogoFrontEndWeb.Models;
using _5_JogoFrontEndWeb.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44387/") });

builder.Services.AddScoped<LoginState>();
builder.Services.AddScoped<Jogador>();
builder.Services.AddScoped<ChamadaAPI>();

builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
