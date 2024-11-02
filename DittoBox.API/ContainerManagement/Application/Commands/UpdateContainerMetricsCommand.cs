using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record UpdateContainerMetricsCommand (
        [Required]double Temperature,
        [Required]double Humidity);
}
