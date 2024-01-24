using PixCharge.Repository.Data;
using PixCharge.Repository.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();

    });
});

/* Registro dos Serviços de Database "Dependency Inversion(Ioc)/Dependency Injection" */
if (builder.Environment.IsStaging())
{
    builder.Services.CreateDataBaseMySqlServer(builder.Configuration);
}
else if (builder.Environment.IsProduction())
{
    builder.Services.CreateDataBaseMsSqlServer(builder.Configuration);
}
else
{
    builder.Services.CreateDataBaseInMemory();
}


builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Cobrança PIX Version 1",
            Version = "1.0.0"
        });
});

var app = builder.Build();

app.UseCors();
app.UseHsts();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Cobrança PIX Version 1");
    });
}

/* Configuração para Debug em Containers Docker/Docker-Compose */
if (app.Environment.IsStaging())
{
    app.Urls.Add("http://0.0.0.0:2000");
    app.Urls.Add("https://0.0.0.0:2001");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

/* Popula base de dados quando estiver em memória */
if (!app.Environment.IsStaging() && !app.Environment.IsProduction())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dataSeeder = services.GetRequiredService<IDataSeeder>();
        dataSeeder.SeedData();
    }
}

app.Run();