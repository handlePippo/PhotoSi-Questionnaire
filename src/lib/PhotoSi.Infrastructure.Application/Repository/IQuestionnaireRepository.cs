using PhotoSi.Questionnaire.Domain.Entities;
using PhotoSi.Questionnaire.Domain.ValueObjects;

namespace PhotoSi.Questionnaire.Application.Repository
{
    /// <summary>
    /// Contract for QuestionnaireRepository.
    /// </summary>
    public interface IQuestionnaireRepository
    {
        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<QuestionItem>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Get a record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<QuestionItem?> GetByIdAsync(QuestionId id, CancellationToken token);

        /// <summary>
        /// Get a specific record by the given keyword.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        Task<IReadOnlyList<QuestionItem>> SearchAsync(QuestionTerm term, CancellationToken token);
    }
}

