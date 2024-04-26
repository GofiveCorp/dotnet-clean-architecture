using Core.Contracts.Repository;
using Core.Features.ToDoLists.Commands.CreateToDoList;
using Domain.Entities;
using FluentValidation.TestHelper;
using Moq;

namespace Core.Test.Features.ToDoLists.Commands.CreateToDoList {
    public class CreateToDoListHandlerTests {
        private readonly Mock<IToDoListRepository> _mockToDoListRepository;

        public CreateToDoListHandlerTests() {
            _mockToDoListRepository = new Mock<IToDoListRepository>();
        }

        private CreateToDoListHandler CreateCreateToDoListHandler() {
            return new CreateToDoListHandler(
                _mockToDoListRepository.Object);
        }

        [Fact]
        public async Task Handle_TitleIsUnique_CreateToDoList() {
            // Arrange
            var createToDoListHandler = this.CreateCreateToDoListHandler();
            CreateToDoListCommand request = new() { 
                Title = "title 1"
            };
            CancellationToken cancellationToken = default;

            var todoListResponse = new ToDoList {
                ToDoListId = 1,
                Title = request.Title,
                DateCreated = DateTime.UtcNow,
            };

            _mockToDoListRepository.Setup(s => s.IsUniqueTitle(request.Title))
                .ReturnsAsync(true);
            _mockToDoListRepository.Setup(s => s.CreateToDoList(request.Title))
                .ReturnsAsync(todoListResponse);

            // Act
            var result = await createToDoListHandler.Handle(
                request,
                cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ToDoListId);
            Assert.Equal(result.Title, result.Title);
        }

        [Fact]
        public async Task Handle_TitleIsNotUnique_CreateToDoListFailed() {
            // Arrange
            var createToDoListHandler = this.CreateCreateToDoListHandler();
            CreateToDoListCommand request = new() {
                Title = "title 1"
            };
            CancellationToken cancellationToken = default;

            _mockToDoListRepository.Setup(s => s.IsUniqueTitle(request.Title))
                .ReturnsAsync(false);

            // Act
            Task result() => createToDoListHandler.Handle(
                request,
                cancellationToken);

            // Assert
            var exception = await Assert.ThrowsAsync<ValidationTestException>(result);

            Assert.NotEmpty(exception.Errors);
            Assert.Single(exception.Errors);
            Assert.Contains("must be unique.", exception.Errors.Select(s => s.ErrorMessage));
        }
    }
}
