using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.GroupManagement.Domain.Models.Commands;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Interfaces
{
    public interface IRegisterContainerCommandHandler
    {
        public Task<ContainerRegistrationResource> Handle(RegisterContainerCommand command);
    }
}