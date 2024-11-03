using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record CreateContainerResource(
            int Id,
            string Name,
            string Description,
            int ContainerSizeId
        )
    {
        public static CreateContainerResource FromContainer(Container container)
        {
            return new CreateContainerResource(
                container.Id,
                container.Name,
                container.Description,
                container.ContainerSizeId
            );
        }
    }
}