using FluentAssertions;
using PhotoSi.Questionnaire.Application.Factory;
using PhotoSi.Questionnaire.Domain.Entities;
using PhotoSi.Questionnaire.Domain.ValueObjects;

namespace PhotoSi.Questionnaire.Application.Tests.Factory
{
    public sealed class QuestionnaireItemFactoryTests
    {
        [Fact]
        public void Map_Should_Map_Single_Item_Correctly()
        {
            var questionId = new QuestionId(1);

            var entity = new QuestionItem(questionId)
            {
                Question = "Q1",
                Answer = "A1"
            };

            var dto = QuestionnaireItemFactory.Map(entity);

            dto.Should().NotBeNull();
            dto.QuestionId.Should().Be("1");
            dto.Question.Should().Be("Q1");
            dto.Answer.Should().Be("A1");
        }

        [Fact]
        public void Map_List_Should_Map_All_Items()
        {
            var items = new List<QuestionItem>
            {
                new QuestionItem(new QuestionId(1)) { Question = "Q1", Answer = "A1" },
                new QuestionItem(new QuestionId(2)) { Question = "Q2", Answer = "A2" }
            };

            var result = QuestionnaireItemFactory.Map(items);

            result.Should().HaveCount(2);
            result[0].QuestionId.Should().Be("1");
            result[1].QuestionId.Should().Be("2");
        }

        [Fact]
        public void Map_Should_Throw_When_Null()
        {
            Assert.Throws<ArgumentNullException>(() => QuestionnaireItemFactory.Map((QuestionItem)null!));
        }

        [Fact]
        public void Map_List_Should_Throw_When_Null()
        {
            Assert.Throws<ArgumentNullException>(() => QuestionnaireItemFactory.Map((IReadOnlyList<QuestionItem>)null!));
        }
    }
}
