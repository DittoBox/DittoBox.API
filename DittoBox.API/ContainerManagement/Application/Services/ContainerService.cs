using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;

namespace DittoBox.API.ContainerManagement.Application.Services
{
    public class ContainerService(IContainerRepository containerRepository) : IContainerService
    {
        public async Task<Container> CreateContainer(string name, string description, int accountId, int groupId, int containerSizeId)
        {
            var container = new Container(name, description, accountId, groupId, containerSizeId);

            // implement validations for accountId and groupId

            await containerRepository.Add(container);
            return container;
        }
        public async Task<Container?> GetContainerById(int id)
        {
            return await containerRepository.GetById(id);
        }
    }
}
