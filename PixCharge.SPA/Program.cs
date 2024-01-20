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

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
    app.UseHsts();
}

if (app.Environment.IsStaging())
{
    app.Urls.Add("http://0.0.0.0:2000");
    app.Urls.Add("https://0.0.0.0:2001");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
