using DittoBox.API.UserProfile.Application.Services;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Models.ValueObjects;
using DittoBox.API.UserProfile.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DittoBox.Tests.UserProfile.Application.Services
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
            var firstname = "John";
            var lastname = "Doe";

            // Act
            var profile = await _profileService.CreateProfile(userId, firstname, lastname);

            // Assert
            _profileRepositoryMock.Verify(repo => repo.Add(It.IsAny<Profile>()), Times.Once);
            Assert.AreEqual(userId, profile.UserId);
            Assert.AreEqual(firstname, profile.FirstName);
            Assert.AreEqual(lastname, profile.LastName);
        }

        [Test]
        public async Task GetProfile_ShouldReturnProfile()
        {
            // Arrange
            var profileId = 1;
            var expectedProfile = new Profile(profileId, "John", "Doe");
            _profileRepositoryMock.Setup(repo => repo.GetById(profileId)).ReturnsAsync(expectedProfile);

            // Act
            var profile = await _profileService.GetProfile(profileId);

            // Assert
            Assert.AreEqual(expectedProfile, profile);
        }

        [Test]
        public async Task DeleteProfile_ShouldRemoveProfile()
        {
            // Arrange
            var profileId = 1;
            var profile = new Profile(profileId, "John", "Doe");
            _profileRepositoryMock.Setup(repo => repo.GetById(profileId)).ReturnsAsync(profile);

            // Act
            await _profileService.DeleteProfile(profileId);

            // Assert
            _profileRepositoryMock.Verify(repo => repo.Delete(profile), Times.Once);
        }

        [Test]
        public async Task GrantPrivilege_ShouldAddPrivilege()
        {
            // Arrange
            var profilePrivilege = new ProfilePrivilege(1, Privilege.GrantPrivilege);
            _profilePrivilegeRepositoryMock.Setup(repo => repo.SamePrivilegeExists(profilePrivilege)).ReturnsAsync(false);

            // Act
            await _profileService.GrantPrivilege(profilePrivilege);

            // Assert
            _profilePrivilegeRepositoryMock.Verify(repo => repo.Add(profilePrivilege), Times.Once);
        }

        [Test]
        public async Task RevokePrivilege_ShouldRemovePrivilege()
        {
            // Arrange
            var profilePrivilege = new ProfilePrivilege(1, Privilege.GrantPrivilege);
            var existingPrivileges = new List<ProfilePrivilege> { profilePrivilege };
            _profilePrivilegeRepositoryMock.Setup(repo => repo.SamePrivilegeExists(profilePrivilege)).ReturnsAsync(true);
            _profilePrivilegeRepositoryMock.Setup(repo => repo.GetAllByProfileId(profilePrivilege.ProfileId)).ReturnsAsync(existingPrivileges);

            // Act
            await _profileService.RevokePrivilege(profilePrivilege);

            // Assert
            _profilePrivilegeRepositoryMock.Verify(repo => repo.Delete(profilePrivilege), Times.Once);
        }

        [Test]
        public async Task ListUserPrivileges_ShouldReturnPrivileges()
        {
            // Arrange
            var profileId = 1;
            var profilePrivileges = new List<ProfilePrivilege>
            {
                new ProfilePrivilege(profileId, Privilege.GrantPrivilege),
                new ProfilePrivilege(profileId, Privilege.SubscriptionManagement)
            };
            _profilePrivilegeRepositoryMock.Setup(repo => repo.GetAllByProfileId(profileId)).ReturnsAsync(profilePrivileges);

            // Act
            var privileges = await _profileService.ListUserPrivileges(profileId);

            // Assert
            Assert.AreEqual(2, privileges.Count);
            Assert.Contains(Privilege.GrantPrivilege, privileges.ToList());
            Assert.Contains(Privilege.SubscriptionManagement, privileges.ToList());
        }

        [Test]
        public async Task UpdateProfile_ShouldUpdateProfile()
        {
            // Arrange
            var profile = new Profile(1, "John", "Doe");

            // Act
            await _profileService.UpdateProfile(profile);

            // Assert
            _profileRepositoryMock.Verify(repo => repo.Update(profile), Times.Once);
        }
    }
}