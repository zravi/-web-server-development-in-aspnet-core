

//
// var builder = WebApplication.CreateBuilder(args);
//
// builder.Services.AddControllers();
//
// builder.Services.AddScoped<IDependency, MyDependency>();
//
// var app = builder.Build();
//
// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();

// var mc = new MenuController();
//
// mc.MenuInit();

namespace MovieCharactersEFCodeFirst;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}