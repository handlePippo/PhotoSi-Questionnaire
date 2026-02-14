using PhotoSi.Questionnaire.Domain.ValueObjects;

namespace PhotoSi.Questionnaire.Domain.Entities
{
    /// <summary>
    /// Domain entity QuestionItem.
    /// </summary>
    public sealed class QuestionItem
    {
        /// <summary>
        /// Question id.
        /// </summary>
        public QuestionId QuestionId { get; private init; }

        /// <summary>
        /// Question.
        /// </summary>
        public string Question { get; set; } = null!;

        /// <summary>
        /// Answer.
        /// </summary>
        public string Answer { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="questionId"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public QuestionItem(QuestionId questionId)
        {
            QuestionId = questionId ?? throw new ArgumentNullException(nameof(questionId));
        }
    }
}
