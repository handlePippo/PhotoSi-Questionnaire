using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PhotoSi.Questionnaire.Configuration.Middlewares;

namespace PhotoSi.Questionnaire.Tests.Configuration.Middlewares
{
    public sealed class GlobalExceptionMiddlewareTests
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly GlobalExceptionMiddleware _middleware;

        public GlobalExceptionMiddlewareTests()
        {
            _logger = Substitute.For<ILogger<GlobalExceptionMiddleware>>();
            _middleware = new GlobalExceptionMiddleware(_logger);
        }

        [Fact]
        public async Task InvokeAsync_Should_Call_Next_When_No_Exception()
        {
            // Arrange
            var context = new DefaultHttpContext();

            var nextCalled = false;

            RequestDelegate next = ctx =>
            {
                nextCalled = true;
                return Task.CompletedTask;
            };

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            nextCalled.Should().BeTrue();
        }

        [Fact]
        public async Task InvokeAsync_Should_Handle_Exception_And_Return_ProblemDetails()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            RequestDelegate next = ctx =>
            {
                throw new Exception("boom");
            };

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            context.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            context.Response.ContentType.Should().Contain("application/json");
            _logger.Received().Log(
                LogLevel.Error,
                Arg.Any<EventId>(),
                Arg.Any<object>(),
                Arg.Any<Exception>(),
                Arg.Any<Func<object, Exception?, string>>()
            );
        }
    }
}
