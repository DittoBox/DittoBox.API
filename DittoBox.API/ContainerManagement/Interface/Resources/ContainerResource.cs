using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record ContainerResource(
            int Id, 
            string Name,
            string Description,
            double Temperature,
            double Humidity,
            ContainerConditions ContainerConditions,
            int LastKnownHealthStatus,
            int LastKnownContainerStatus,
            DateTime LastSync
        )
    {
        public static ContainerResource FromContainer(Container container)
        {
            return new ContainerResource(
                container.Id, 
                container.Name, 
                container.Description,
                container.Temperature,
                container.Humidity,
                container.ContainerConditions,
                container.LastKnownHealthStatus,
                container.LastKnownContainerStatus,
                container.LastSync
            );
        }
    }
}