using PhotoSi.Questionnaire.Application.Repository;
using PhotoSi.Questionnaire.Application.Service;
using PhotoSi.Questionnaire.Configuration.Middlewares;
using PhotoSi.Questionnaire.Infrastructure.Repository;

namespace PhotoSi.Questionnaire.Configuration
{
    /// <summary>
    /// Dependency injection.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Exstension for IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionMiddleware>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();
            services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
        }
    }
}
