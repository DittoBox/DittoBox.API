using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Domain.Services.Application
{
    public interface IContainerService
    {
        public Task<Container> CreateContainer(string name, string description, int accountId, int groupId, int containerSizeId);
        public Task<Container?> GetContainerById(int id);
        public Task UpdateContainer(Container container);
		public Task<IEnumerable<Container>> GetContainers();
    }
}
