using PhotoSi.Infrastructure.Application.DTOs;

namespace PhotoSi.Infrastructure.Application.Service
{
    /// <summary>
    /// Contract for QuestionnaireService.
    /// </summary>
    public interface IQuestionnaireService
    {
        /// <summary>
        /// Gets all record.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IReadOnlyList<QuestionItemDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Get a record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<QuestionItemDto?> GetByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Search a specific record by the given keyword.
        /// </summary>
        /// <param name="term"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IReadOnlyList<QuestionItemDto>> SearchAsync(string term, CancellationToken token);
    }
}

