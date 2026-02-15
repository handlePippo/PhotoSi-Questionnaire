using PhotoSi.Questionnaire.Application.DTOs;
using PhotoSi.Questionnaire.Domain.Entities;

namespace PhotoSi.Questionnaire.Application.Factory
{
    /// <summary>
    /// Factory to generate TDto from T.
    /// </summary>
    public static class QuestionnaireItemFactory
    {
        /// <summary>
        /// Maps from T to TDto.
        /// </summary>
        /// <param name="questionItem"></param>
        /// <returns></returns>
        public static QuestionItemDto Map(QuestionItem questionItem)
        {
            ArgumentNullException.ThrowIfNull(questionItem);

            return new QuestionItemDto
            {
                QuestionId = questionItem.QuestionId.Value,
                Question = questionItem.Question,
                Answer = questionItem.Answer
            };
        }

        /// <summary>
        /// Maps from List<T> to List<TDto>
        /// </summary>
        /// <param name="questionItems"></param>
        /// <returns></returns>
        public static IReadOnlyList<QuestionItemDto> Map(IReadOnlyList<QuestionItem> questionItems)
        {
            ArgumentNullException.ThrowIfNull(questionItems);

            return questionItems
                .Select(Map)
                .ToList()
                .AsReadOnly();
        }
    }
}
