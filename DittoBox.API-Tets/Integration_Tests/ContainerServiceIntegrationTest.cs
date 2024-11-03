using NUnit.Framework;
using Moq;
using DittoBox.API.ContainerManagement.Application.Services;
using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace DittoBox.Tests.Integration
{
    [TestFixture]
    public class ContainerServiceTests
    {
        private Mock<IContainerRepository> _containerRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ContainerService _containerService;

        [SetUp]
        public void Setup()
        {
            _containerRepositoryMock = new Mock<IContainerRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _containerService = new ContainerService(_containerRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Test]
        public async Task CreateContainer_ShouldAddContainer()
        {
            // Arrange
            var name = "Test Container";
            var description = "This is a test container";
            var accountId = 1;
            var groupId = 1;
            var containerSizeId = 1;

            // Act
            var container = await _containerService.CreateContainer(name, description, accountId, groupId, containerSizeId);

            // Assert
            _containerRepositoryMock.Verify(repo => repo.Add(It.IsAny<Container>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CompleteAsync(), Times.Once);
            Assert.AreEqual(name, container.Name);
            Assert.AreEqual(description, container.Description);
            Assert.AreEqual(accountId, container.AccountId);
            Assert.AreEqual(groupId, container.GroupId);
            Assert.AreEqual(containerSizeId, container.ContainerSizeId);
        }
    }
}