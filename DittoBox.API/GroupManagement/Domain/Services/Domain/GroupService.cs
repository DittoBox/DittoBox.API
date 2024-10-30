using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Models.ValueObject;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.GroupManagement.Domain.Services.Application;

namespace DittoBox.API.GroupManagement.Domain.Services.Domain
{
    public class GroupService(
        IGroupRepository groupRepository
    ) : IGroupService
    {
        public async Task<Group> CreateGroup(int accountId, string name, Location location, FacilityType facilityType)
        {
            var group = new Group(accountId, name, location, facilityType);
            await groupRepository.Add(group);
            return group;
        }
        public async Task DeleteGroup(int id)
        {
            var group = await groupRepository.GetById(id);
            if (group != null)
            {
                await groupRepository.Delete(group);
            }
        }

        public async Task<Group> GetGroup(int id)
        {
            var group = await groupRepository.GetById(id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            return group;
        }

        public IEnumerable<Group> GetGroups(int accountId)
        {
            throw new NotImplementedException();
        }


        public void RegisterContainer(int groupId, int containerId)
        {
            throw new NotImplementedException();
        }

        public Group UpdateGroup(int id, string name, Location location)
        {
            // Implementación del método
            throw new NotImplementedException();
        }

        Task<IEnumerable<Group>> IGroupService.GetGroups(int accountId)
        {
            throw new NotImplementedException();
        }

        Task IGroupService.RegisterContainer(int groupId, int containerId)
        {
            throw new NotImplementedException();
        }

        Task<Group> IGroupService.UpdateGroup(int id, string name, Location location)
        {
            throw new NotImplementedException();
        }
    }
}