using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using DittoBox.API.GroupManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal
{
    public class CreateGroupCommandHandler : ICreateGroupCommandHandler
    {
        private readonly IGroupService _groupService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGroupCommandHandler(IGroupService groupService, IUnitOfWork unitOfWork)
        {
            _groupService = groupService;
            _unitOfWork = unitOfWork;
        }

        public async Task<GroupResource> Handle(CreateGroupCommand command)
        {
            var result = await _groupService.CreateGroup(command.Name, command.location, command.AccountId);
            await _unitOfWork.CompleteAsync();
            return GroupResourceExtensions.ToResource(result);
        }
    }
}