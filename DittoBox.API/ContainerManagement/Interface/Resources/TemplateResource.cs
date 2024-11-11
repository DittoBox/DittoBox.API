using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record TemplateResource(
        int Id,
        string Name,
        sbyte MaxTemperatureThreshold,
        sbyte MinTemperatureThreshold,
        float MaxHumidityThreshold,
        float MinHumidityThreshold,
        int? MaxOxygenThreshold,
        int? MinCarbonDioxideThreshold,
        int? MaxCarbonDioxideThreshold,
        int? MinOxygenThreshold,
        int? MinSulfurDioxideThreshold,
        int? MaxSulfurDioxideThreshold,
        int? MinEthyleneThreshold,
        int? MaxEthyleneThreshold,
        int? MinAmmoniaThreshold,
        int? MaxAmmoniaThreshold,
		TemplateCategory Category
    ) {
		public static TemplateResource FromTemplate(DittoBox.API.ContainerManagement.Domain.Models.Entities.Template template)
		{
			return new TemplateResource(
				template.Id,
				template.Name,
				template.MaxTemperatureThreshold,
				template.MinTemperatureThreshold,
				template.MaxHumidityThreshold,
				template.MinHumidityThreshold,
				template.MaxOxygenThreshold,
				template.MinCarbonDioxideThreshold,
				template.MaxCarbonDioxideThreshold,
				template.MinOxygenThreshold,
				template.MinSulfurDioxideThreshold,
				template.MaxSulfurDioxideThreshold,
				template.MinEthyleneThreshold,
				template.MaxEthyleneThreshold,
				template.MinAmmoniaThreshold,
				template.MaxAmmoniaThreshold,
				template.Category
			);
		}
	}
}