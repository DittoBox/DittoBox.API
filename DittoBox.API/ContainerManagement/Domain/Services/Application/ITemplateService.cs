using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Services.Application
{
	public interface ITemplateService
	{
		Task<Template?> GetTemplate(int templateId);
		Task<IEnumerable<Template>> GetTemplates();
		Task<Template> CreateTemplate(
			string name,
			sbyte maxTemperatureThreshold,
			sbyte minTemperatureThreshold,
			sbyte maxHumidityThreshold,
			sbyte minHumidityThreshold,
			int? maxOxygenThreshold,
			int? minCarbonDioxideThreshold,
			int? maxCarbonDioxideThreshold,
			int? minOxygenThreshold,
			int? minSulfurDioxideThreshold,
			int? maxSulfurDioxideThreshold,
			int? minEthyleneThreshold,
			int? maxEthyleneThreshold,
			int? minAmmoniaThreshold,
			int? maxAmmoniaThreshold,
			TemplateCategory category
		);
	}
}