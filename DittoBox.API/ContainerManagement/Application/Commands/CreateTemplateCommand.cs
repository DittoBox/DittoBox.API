namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record CreateTemplateCommand(
        string Name,
        sbyte MaxTemperatureThreshold,
        sbyte MinTemperatureThreshold,
        sbyte MaxHumidityThreshold,
        sbyte MinHumidityThreshold,
        int? MaxOxygenThreshold,
		int? MinOxygenThreshold,
        int? MinCarbonDioxideThreshold,
        int? MaxCarbonDioxideThreshold,
        int? MinSulfurDioxideThreshold,
        int? MaxSulfurDioxideThreshold,
        int? MinEthyleneThreshold,
        int? MaxEthyleneThreshold,
        int? MinAmmoniaThreshold,
        int? MaxAmmoniaThreshold
    );
}