using System.ComponentModel.DataAnnotations;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record CreateTemplateCommand(
        [Required] string Name,
        [Required] sbyte MaxTemperatureThreshold,
        [Required] sbyte MinTemperatureThreshold,
        [Required] sbyte MaxHumidityThreshold,
        [Required] sbyte MinHumidityThreshold,
        [Required] sbyte? MaxOxygenThreshold,
        [Required] sbyte? MinOxygenThreshold,
        [Required] sbyte? MaxCarbonDioxideThreshold,
        [Required] sbyte? MinCarbonDioxideThreshold,
        [Required] sbyte? MinSulfurDioxideThreshold,
        [Required] sbyte? MaxSulfurDioxideThreshold,
        [Required] sbyte? MinEthyleneThreshold,
        [Required] sbyte? MaxEthyleneThreshold,
        [Required] sbyte? MinAmmoniaThreshold,
        [Required] sbyte? MaxAmmoniaThreshold,
        [Required] TemplateCategory Category
    );
}