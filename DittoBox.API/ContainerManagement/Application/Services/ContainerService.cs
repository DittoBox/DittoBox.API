using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;

namespace DittoBox.API.ContainerManagement.Application.Services
{
    public class ContainerService(IContainerRepository containerRepository) : IContainerService
    {
        public async Task<Container> CreateContainer(string name, string description, int accountId, int groupId, int containerSizeId)
        {
            var container = new Container(name, name, description, accountId, groupId, containerSizeId);

            // implement validations for accountId and groupId

            await containerRepository.Add(container);
            return container;
        }
        public async Task<IEnumerable<Container>> GetAllByGroupId(int groupId)
        {
            var containers = await containerRepository.GetAllByGroupId(groupId);
            return containers;
        }
    }
}
