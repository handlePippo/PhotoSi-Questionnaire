using PhotoSi.Questionnaire.Application.Repository;
using PhotoSi.Questionnaire.Domain.Entities;
using PhotoSi.Questionnaire.Domain.ValueObjects;
using System.Text.Json;

namespace PhotoSi.Questionnaire.Infrastructure.Repository
{
    public sealed class QuestionnaireRepository : IQuestionnaireRepository
    {
        private const string JsonFolderName = "Data";
        private const string JsonFileName = "questionnaire.json";

        private readonly Lazy<IReadOnlyList<QuestionItem>> _cache;

        public QuestionnaireRepository()
        {
            _cache = new Lazy<IReadOnlyList<QuestionItem>>(() =>
            {
                var path = Path.Combine(AppContext.BaseDirectory, JsonFolderName, JsonFileName);
                var json = File.ReadAllText(path);

                var items = JsonSerializer.Deserialize<List<QuestionItem>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return items ?? [];
            });
        }

        public Task<IReadOnlyList<QuestionItem>> GetAllAsync(CancellationToken _) => Task.FromResult(_cache.Value);

        public Task<QuestionItem?> GetByIdAsync(QuestionId id, CancellationToken _)
        {
            var result = _cache
                .Value
                .FirstOrDefault(x => x.QuestionId == id);

            return Task.FromResult(result);
        }

        public Task<IReadOnlyList<QuestionItem>> SearchAsync(QuestionTerm term, CancellationToken _)
        {
            ArgumentNullException.ThrowIfNull(term);

            var stringTerm = term.Value.Trim();

            var result = _cache
                .Value
                .Where(question =>
                           question
                           .Question
                           .Contains(stringTerm, StringComparison.OrdinalIgnoreCase)
                            ||
                           question
                           .Answer
                           .Contains(stringTerm, StringComparison.OrdinalIgnoreCase))
                .ToList()!
                .AsReadOnly();

            return Task.FromResult<IReadOnlyList<QuestionItem>>(result);
        }
    }
}

