using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Domain.Services.Application
{
    public interface IContainerService
    {
        public Task<Container> CreateContainer(string name, string description, int accountId, int groupId, int containerSizeId);
        public Task<IEnumerable<Container>> GetAllByGroupId(int groupId);
    }
}
