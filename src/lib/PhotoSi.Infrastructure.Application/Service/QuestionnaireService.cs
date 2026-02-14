using PhotoSi.Infrastructure.Application.DTOs;
using PhotoSi.Infrastructure.Application.Factory;
using PhotoSi.Infrastructure.Application.Repository;

namespace PhotoSi.Infrastructure.Application.Service
{
    /// <summary>
    /// Implementation of QuestionnaireService.
    /// </summary>
    public sealed class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _repository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repository"></param>
        public QuestionnaireService(IQuestionnaireRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<QuestionItemDto>> GetAllAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var questionItems = await _repository.GetAllAsync(token);

            if (questionItems is null)
            {
                return Array.Empty<QuestionItemDto>()!;
            }

            return QuestionnaireItemFactory.Map(questionItems);
        }

        public async Task<QuestionItemDto?> GetByIdAsync(int id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var questionItem = await _repository.GetByIdAsync(id, token);

            if (questionItem is null)
            {
                return null;
            }

            QuestionItemDto questionItemDto = questionItem;
            return questionItemDto;
        }

        public async Task<IReadOnlyList<QuestionItemDto>> SearchAsync(string term, CancellationToken token)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(term);
            token.ThrowIfCancellationRequested();

            var questionItems = await _repository.SearchAsync(term, token);

            if (questionItems is null)
            {
                return Array.Empty<QuestionItemDto>()!;
            }

            return QuestionnaireItemFactory.Map(questionItems);
        }
    }
}

