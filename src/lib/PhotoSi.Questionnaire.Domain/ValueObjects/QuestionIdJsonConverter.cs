using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhotoSi.Questionnaire.Domain.ValueObjects
{
    public sealed class QuestionIdJsonConverter : JsonConverter<QuestionId>
    {
        public override QuestionId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.Number when reader.TryGetInt32(out var n) => new QuestionId(n),
                JsonTokenType.String => new QuestionId(reader.GetString()!),
                _ => throw new JsonException("Invalid QuestionId.")
            };
        }

        public override void Write(Utf8JsonWriter writer, QuestionId value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Value);
    }
}

