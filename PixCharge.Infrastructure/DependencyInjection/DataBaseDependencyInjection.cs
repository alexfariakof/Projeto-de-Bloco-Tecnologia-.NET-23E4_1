using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PixCharge.Infrastructure.DependenceInject;
public static class DataBaseDependencyInjection
{
    public static void CreateDataBaseMySqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RegisterContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("MySqlConnectionString"),
                b => b.MigrationsAssembly("PixCharge.Infrastructure.Migrations_MySqlServer")));
    }
    public static void CreateDataBaseMsSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RegisterContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"),
            b => b.MigrationsAssembly("PixCharge.Infrastructure.Migrations_MsSqlServer")));

    }
    public static void CreateDataBaseInMemory(this IServiceCollection services)
    {
        services.AddDbContext<RegisterContext>(c => c.UseInMemoryDatabase("Register"));
        //services.AddTransient<IDataSeeder, DataSeeder>();
    }
}