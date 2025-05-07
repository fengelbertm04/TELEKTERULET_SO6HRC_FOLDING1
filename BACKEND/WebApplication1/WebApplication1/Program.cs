using TelekAPI.Data;

namespace TelekAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IAreaRepository, AreaRepository>();

            var app = builder.Build();


            app.MapGet("/", () => "Hello World!");

            app.UseCors(x => x
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500"));
            app.Run();

        }
    }
}
