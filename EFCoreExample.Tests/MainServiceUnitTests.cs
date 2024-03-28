using Xunit;
using Moq;
using EFCoreExample.Contexts.Repositories;
using EFCoreExample.Helpers;
using EFCoreExample.Models;
using EFCoreExample.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreExample.Tests
{
    public class MainServiceUnitTests
    {
        [Fact]
        public async Task AddClassroomAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            var mockConsoleService = new Mock<IConsoleService>();
            mockConsoleService.Setup(cs => cs.ReadLine()).Returns("Test Classroom");
            var dummyClassroom = new Classroom { ClassroomId = 1, Name = "Test Classroom" };
            mockRepo.Setup(repo => repo.AddClassroomAsync(It.IsAny<Classroom>())).ReturnsAsync(dummyClassroom);
            var service = new MainService(mockRepo.Object, mockConsoleService.Object);

            // Act
            await service.AddClassroomAsync();

            // Assert
            mockRepo.Verify(repo => repo.AddClassroomAsync(It.IsAny<Classroom>()), Times.Once);
        }


        [Fact]
        public async Task AddStudentToClassroomAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            var mockConsoleService = new Mock<IConsoleService>();
            mockConsoleService.SetupSequence(cs => cs.ReadLine()).Returns("1").Returns("Test Student");
            var service = new MainService(mockRepo.Object, mockConsoleService.Object);

            // Act
            await service.AddStudentToClassroomAsync();

            // Assert
            mockRepo.Verify(repo => repo.AddStudentToClassroomAsync(It.IsAny<int>(), It.IsAny<Student>()), Times.Once);
        }

        [Fact]
        public async Task ListClassroomsAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            var mockConsoleService = new Mock<IConsoleService>();
            mockRepo.Setup(repo => repo.GetAllClassroomsAsync()).ReturnsAsync(new List<Classroom>());
            var service = new MainService(mockRepo.Object, mockConsoleService.Object);

            // Act
            await service.ListClassroomsAsync();

            // Assert
            mockRepo.Verify(repo => repo.GetAllClassroomsAsync(), Times.Once);
        }

        [Fact]
        public async Task ListStudentsInClassroomAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            var mockConsoleService = new Mock<IConsoleService>();
            mockConsoleService.Setup(cs => cs.ReadLine()).Returns("1");
            mockRepo.Setup(repo => repo.GetStudentsInClassroomAsync(It.IsAny<int>())).ReturnsAsync(new List<Student>());
            var service = new MainService(mockRepo.Object, mockConsoleService.Object);

            // Act
            await service.ListStudentsInClassroomAsync();

            // Assert
            mockRepo.Verify(repo => repo.GetStudentsInClassroomAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
