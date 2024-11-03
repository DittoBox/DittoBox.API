using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Services
{
	public class ContainerService(
		IContainerRepository containerRepository,
		IUnitOfWork unitOfWork
	) : IContainerService
	{
		public async Task<Container> CreateContainer(string name, string description, int accountId, int groupId, int containerSizeId)
		{
			var container = new Container(name, description, accountId, groupId, containerSizeId);

			// implement validations for accountId and groupId

			await containerRepository.Add(container);
			await unitOfWork.CompleteAsync();
			return container;
		}
		public async Task<Container?> GetContainerById(int id)
		{
			return await containerRepository.GetById(id);
		}

		public async Task UpdateContainer(Container container)
		{
			await containerRepository.Update(container);
			await unitOfWork.CompleteAsync();
		}
	}
}
