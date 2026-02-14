using AutoFixture;
using FluentAssertions;
using NSubstitute;
using PhotoSi.Infrastructure.Application.Repository;
using PhotoSi.Infrastructure.Application.Service;
using PhotoSi.Questionnaire.Domain.Entities;

namespace PhotoSi.Questionnaire.Application.Tests.Service
{
    public sealed class QuestionnaireServiceTests
    {
        private readonly Fixture _fixture = new();
        private readonly QuestionnaireService _sut;
        private readonly IQuestionnaireRepository _repository = Substitute.For<IQuestionnaireRepository>();

        public QuestionnaireServiceTests()
        {
            _fixture.Inject(_repository);
            _sut = _fixture.Create<QuestionnaireService>();
        }

        [Fact]
        public async Task GetAllAsync_WhenRepositoryReturnsNull_ReturnsEmpty()
        {
            _repository.GetAllAsync(Arg.Any<CancellationToken>())
                .Returns(Task.FromResult((IReadOnlyList<QuestionItem>)null!));

            var result = await _sut.GetAllAsync(default);

            result.Should().BeEmpty();
            await _repository.Received(1).GetAllAsync(default);
        }

        [Fact]
        public async Task GetByIdAsync_WhenRepositoryReturnsNull_ReturnsNull()
        {
            var id = 1;

            _repository.GetByIdAsync(id, Arg.Any<CancellationToken>())
                .Returns((QuestionItem?)null);

            var result = await _sut.GetByIdAsync(id, default);

            result.Should().BeNull();
            await _repository.Received(1).GetByIdAsync(id, default);
        }

        [Fact]
        public async Task SearchAsync_WhenTermIsWhitespace_Throws()
        {
            Func<Task> act = () => _sut.SearchAsync(" ", default);

            await act.Should().ThrowAsync<ArgumentException>();

            await _repository.DidNotReceiveWithAnyArgs().SearchAsync(default!, default);
        }

        [Fact]
        public async Task SearchAsync_WhenRepositoryReturnsNull_ReturnsEmpty()
        {
            var term = "dotnet";

            _repository.SearchAsync(term, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult((IReadOnlyList<QuestionItem>)null!));

            var result = await _sut.SearchAsync(term, default);

            result.Should().BeEmpty();
            await _repository.Received(1).SearchAsync(term, default);
        }
    }
}