using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PhotoSi.Infrastructure.Application.DTOs;
using PhotoSi.Infrastructure.Application.Service;
using PhotoSi.Questionnaire.Api.Controllers;

namespace PhotoSi.Questionnaire.Api.Tests.Controllers
{
    public sealed class QuestionnaireControllerTests
    {
        private readonly QuestionnaireController _sut;
        private readonly IQuestionnaireService _service;

        public QuestionnaireControllerTests()
        {
            _service = Substitute.For<IQuestionnaireService>();
            _sut = new QuestionnaireController(_service);
        }

        [Fact]
        public async Task GetAll_Should_Return_Ok_When_Items_Exist()
        {
            // Arrange
            var items = new List<QuestionItemDto>
            {
                new QuestionItemDto
                {
                    QuestionId = "1",
                    Question = "Q1",
                    Answer = "A1"
                }
            };

            _service.GetAllAsync(Arg.Any<CancellationToken>())
                    .Returns(items);

            // Act
            var result = await _sut.GetAll(CancellationToken.None);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(items);

            await _service.Received(1).GetAllAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetAll_Should_Return_NotFound_When_Null()
        {
            // Arrange
            _service.GetAllAsync(Arg.Any<CancellationToken>())
                    .Returns((IReadOnlyList<QuestionItemDto>?)null!);

            // Act
            var result = await _sut.GetAll(CancellationToken.None);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
            await _service.Received(1).GetAllAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetById_Should_Return_Ok_When_Item_Exists()
        {
            // Arrange
            var dto = new QuestionItemDto
            {
                QuestionId = "1",
                Question = "Q1",
                Answer = "A1"
            };

            _service.GetByIdAsync(1, Arg.Any<CancellationToken>())
                    .Returns(dto);

            // Act
            var result = await _sut.GetById(1, CancellationToken.None);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(dto);

            await _service.Received(1).GetByIdAsync(1, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetById_Should_Return_NotFound_When_Item_NotFound()
        {
            // Arrange
            _service.GetByIdAsync(1, Arg.Any<CancellationToken>())
                    .Returns((QuestionItemDto?)null);

            // Act
            var result = await _sut.GetById(1, CancellationToken.None);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
            await _service.Received(1).GetByIdAsync(1, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_Should_Return_Ok_When_Items_Exist()
        {
            // Arrange
            var items = new List<QuestionItemDto>
            {
                new QuestionItemDto
                {
                    QuestionId = "1",
                    Question = "Q1",
                    Answer = "A1"
                }
            };

            _service.SearchAsync("dotnet", Arg.Any<CancellationToken>())
                    .Returns(items);

            // Act
            var result = await _sut.Search("dotnet", CancellationToken.None);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(items);

            await _service.Received(1).SearchAsync("dotnet", Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Search_Should_Return_NotFound_When_Null()
        {
            // Arrange
            _service.SearchAsync("dotnet", Arg.Any<CancellationToken>())
                    .Returns((IReadOnlyList<QuestionItemDto>?)null!);

            // Act
            var result = await _sut.Search("dotnet", CancellationToken.None);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
            await _service.Received(1).SearchAsync("dotnet", Arg.Any<CancellationToken>());
        }
    }
}
