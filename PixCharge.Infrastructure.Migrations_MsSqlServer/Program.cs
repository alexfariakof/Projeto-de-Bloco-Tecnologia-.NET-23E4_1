using PixCharge.Repository.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.CreateDataBaseMsSqlServer(builder.Configuration);
var app = builder.Build();
app.MapGet("/", () => "Migrations MsSql Server!");
app.Run();