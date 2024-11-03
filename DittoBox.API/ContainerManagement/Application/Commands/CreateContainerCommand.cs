﻿using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record CreateContainerCommand(
        [Required] string Name,
        [Required] string Description,
        [Required] int AccountId,
        [Required] int GroupId,
        [Required] int ContainerSizeId
    );
}