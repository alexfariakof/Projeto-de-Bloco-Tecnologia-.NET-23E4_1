using PixCharge.Repository.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.CreateDataBaseMySqlServer(builder.Configuration);
var app = builder.Build();
app.MapGet("/", () => "Migrations MySql Server!");
app.Run();


