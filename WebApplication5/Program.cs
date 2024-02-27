using WebApplication5.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStatistics();

app.Run();
