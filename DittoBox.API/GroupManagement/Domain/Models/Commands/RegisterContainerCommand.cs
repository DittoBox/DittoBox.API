using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.GroupManagement.Domain.Models.Commands
{
    public record RegisterContainerCommand(
        [Required] int GroupId,
        [Required] int ContainerId,
        [Required] int AccountId,
        [Required] string Code
    );
}