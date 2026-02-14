using System.Text.Json.Serialization;

namespace PhotoSi.Questionnaire.Domain.ValueObjects
{
    /// <summary>
    /// Question id value object.
    /// </summary>
    /// 
    [JsonConverter(typeof(QuestionIdJsonConverter))]
    public sealed class QuestionId : IEquatable<QuestionId>
    {
        public string Value { get; }

        public QuestionId(int value)
        {
            Value = value.ToString();
        }

        public QuestionId(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

            Value = value;
        }

        public bool Equals(QuestionId? other) => Value == other?.Value;

        #region overrides

        public override bool Equals(object? obj) => obj is QuestionId questionId && Equals(questionId);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value;

        #endregion

        #region op redefinition

        public static bool operator !=(QuestionId? left, QuestionId? right) => !(left == right);
        public static bool operator ==(QuestionId? left, QuestionId? right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static implicit operator QuestionId(int questionId) => new QuestionId(questionId);

        #endregion
    }
}
