using NUnit.Framework;
using Moq;
using DittoBox.API.UserProfile.Application.Services;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;
using System.Threading.Tasks;

namespace DittoBox.Tests.Integration
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Test]
        public async Task CreateUser_ShouldAddUser()
        {
            // Arrange
            var username = "testuser";
            var email = "testuser@example.com";
            var password = "password123";

            // Act
            var user = await _userService.CreateUser(username, email, password);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Add(It.IsAny<User>()), Times.Once);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(_userService.EncryptPassword(password), user.Password);
        }
    }
}