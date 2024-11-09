namespace DittoBox.API.GroupManagement.Domain.Models.Commands
{
    public interface IRegisterContainerCommandHandler
    {
        public Task Handle(RegisterContainerCommand command);
    }
}