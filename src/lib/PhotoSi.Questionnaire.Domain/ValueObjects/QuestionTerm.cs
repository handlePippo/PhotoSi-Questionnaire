namespace PhotoSi.Questionnaire.Domain.ValueObjects
{
    /// <summary>
    /// Question id value object.
    /// </summary>
    public sealed class QuestionTerm : IEquatable<QuestionTerm>
    {
        public string Value { get; private init; }

        public QuestionTerm(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

            Value = value;
        }

        public bool Equals(QuestionTerm? other) => Value == other?.Value;

        #region overrides

        public override bool Equals(object? obj) => obj is QuestionTerm questionTerm && Equals(questionTerm);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value;

        #endregion

        #region op redefinition

        public static bool operator !=(QuestionTerm? left, QuestionTerm? right) => !(left == right);
        public static bool operator ==(QuestionTerm? left, QuestionTerm? right)
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

        public static implicit operator QuestionTerm(string questionTerm) => new QuestionTerm(questionTerm);

        #endregion
    }
}
