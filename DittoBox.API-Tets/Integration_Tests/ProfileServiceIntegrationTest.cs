using NUnit.Framework;
using Moq;
using DittoBox.API.UserProfile.Application.Services;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;
using System.Threading.Tasks;

namespace DittoBox.Tests.Integration
{
    [TestFixture]
    public class ProfileServiceTests
    {
        private Mock<IProfileRepository> _profileRepositoryMock;
        private Mock<IProfilePrivilegeRepository> _profilePrivilegeRepositoryMock;
        private ProfileService _profileService;

        [SetUp]
        public void Setup()
        {
            _profileRepositoryMock = new Mock<IProfileRepository>();
            _profilePrivilegeRepositoryMock = new Mock<IProfilePrivilegeRepository>();
            _profileService = new ProfileService(_profileRepositoryMock.Object, _profilePrivilegeRepositoryMock.Object);
        }

        [Test]
        public async Task CreateProfile_ShouldAddProfile()
        {
            // Arrange
            var userId = 1;
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var profile = await _profileService.CreateProfile(userId, firstName, lastName);

            // Assert
            _profileRepositoryMock.Verify(repo => repo.Add(It.IsAny<Profile>()), Times.Once);
            Assert.AreEqual(userId, profile.UserId);
            Assert.AreEqual(firstName, profile.FirstName);
            Assert.AreEqual(lastName, profile.LastName);
        }
    }
}