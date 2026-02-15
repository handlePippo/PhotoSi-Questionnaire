using PhotoSi.Questionnaire.Application.Factory;
using PhotoSi.Questionnaire.Domain.Entities;

namespace PhotoSi.Questionnaire.Application.DTOs
{
    /// <summary>
    /// DTO represting a QuestionItem entity.
    /// </summary>
    public sealed record QuestionItemDto
    {
        /// <summary>
        /// Question id.
        /// </summary>
        public string QuestionId { get; set; } = null!;

        /// <summary>
        /// Question.
        /// </summary>
        public string Question { get; set; } = null!;

        /// <summary>
        /// Answer.
        /// </summary>
        public string Answer { get; set; } = null!;

        /// <summary>
        /// Implicit operator redefinition.
        /// </summary>
        /// <param name="questionItem"></param>
        public static implicit operator QuestionItemDto(QuestionItem questionItem) => QuestionnaireItemFactory.Map(questionItem);
    }
}

