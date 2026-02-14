using AutoFixture;
using FluentAssertions;
using PhotoSi.Questionnaire.Infrastructure.Repository;

namespace PhotoSi.Questionnaire.Infrastructure.Tests.Repository
{
    public sealed class QuestionnaireRepositoryTests
    {
        private readonly Fixture _fixture = new();
        private readonly QuestionnaireRepository _sut;

        public QuestionnaireRepositoryTests()
        {
            _sut = _fixture.Create<QuestionnaireRepository>();

            CreateTestJson();
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Items()
        {
            var result = await _sut.GetAllAsync(CancellationToken.None);

            result.Should().HaveCount(2);
        }

        private static void CreateTestJson()
        {
            var folder = Path.Combine(AppContext.BaseDirectory, "Data");
            var filePath = Path.Combine(folder, "questionnaire.json");

            Directory.CreateDirectory(folder);

            var json = """
                [
                  { "questionId": "1", "question": "What is .NET?", "answer": ".NET is a platform." },
                  { "questionId": "2", "question": "What is C#?", "answer": "A programming language." }
                ]
                """;

            File.WriteAllText(filePath, json);
        }
    }
}