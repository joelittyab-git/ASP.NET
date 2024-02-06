using GameStore.Repositries;
using GameStore.Routers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemoryService>();
var app = builder.Build();
app.MapGamesEndpoint();

app.Run();
