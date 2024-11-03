using DittoBox.API.UserProfile.Application.Services;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DittoBox.Tests.UserProfile.Application.Services
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
            Assert.AreNotEqual(password, user.Password); // Password should be encrypted
        }

        [Test]
        public async Task GetUser_ShouldReturnUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new User("testuser", "password123", "testuser@example.com");
            _userRepositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync(expectedUser);

            // Act
            var user = await _userService.GetUser(userId);

            // Assert
            Assert.AreEqual(expectedUser, user);
        }

        [Test]
        public async Task DeleteUser_ShouldRemoveUser()
        {
            // Arrange
            var userId = 1;
            var user = new User("testuser", "password123", "testuser@example.com");
            _userRepositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync(user);

            // Act
            await _userService.DeleteUser(userId);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Delete(user), Times.Once);
        }

        [Test]
        public async Task UpdateUser_ShouldUpdateUser()
        {
            // Arrange
            var user = new User("testuser", "password123", "testuser@example.com");

            // Act
            await _userService.UpdateUser(user);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Update(user), Times.Once);
        }

        [Test]
        public void EncryptPassword_ShouldReturnHashedPassword()
        {
            // Arrange
            var password = "password123";

            // Act
            var hashedPassword = _userService.EncryptPassword(password);

            // Assert
            Assert.AreNotEqual(password, hashedPassword);
            Assert.AreEqual(64, hashedPassword.Length); // SHA256 hash length in hex is 64 characters
        }
    }
}