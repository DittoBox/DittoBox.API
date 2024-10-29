using System.ComponentModel.DataAnnotations;
using DittoBox.API.GroupManagement.Domain.Models.Entities;

namespace DittoBox.API.GroupManagement.Domain.Models.Commands
{
    public record CreateGroupCommand(
        [Required, StringLength(64)] string Name,
        [Required, StringLength(64)] Location location,
        [Required] int AccountId
    );
}