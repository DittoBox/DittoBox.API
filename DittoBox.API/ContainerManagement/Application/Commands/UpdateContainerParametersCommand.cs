using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record UpdateContainerParametersCommand (
        [Required] double MinTemp, [Required] double MaxTemp,
        [Required] double MinHumidity, [Required] double MaxHumidity,
        [Required] double OxygenMin, [Required] double OxygenMax,
        [Required] double DioxideMin, [Required] double DioxideMax,
        [Required] double EthyleneMin, [Required] double EthyleneMax,
        [Required] double AmmoniaMin, [Required] double AmmoniaMax,
        [Required] double SulfurDioxideMin, [Required] double SulfurDioxideMax);
}