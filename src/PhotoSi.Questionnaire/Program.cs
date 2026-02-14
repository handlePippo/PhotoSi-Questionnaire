using PhotoSi.Questionnaire.Configuration;
using PhotoSi.Questionnaire.Configuration.Middlewares;

namespace PhotoSi.Questionnaire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure services
            builder.Services.ConfigureServices();

            // Configure logging
            builder.Logging.AddConsole();

            // Configure health checks
            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
