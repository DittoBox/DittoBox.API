using DittoBox.API.GroupManagement.Domain.Models.Entities;

namespace DittoBox.API.GroupManagement.Domain.Services.Application
{
    public interface IGroupService
    {
        public Task<Group> CreateGroup(string name, Location location, int accountId);
        public Task<Group> GetGroup(int id);
        public Task<IEnumerable<Group>> GetGroups(int accountId);
        public Task<Group> UpdateGroup(int id, string name, Location location);
        public Task DeleteGroup(int id);
    }
}