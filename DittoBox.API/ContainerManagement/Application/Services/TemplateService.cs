using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Services
{
	class TemplateService(ITemplateRepository templateRepository, IUnitOfWork unitOfWork) : ITemplateService
	{

		public async Task<Template> CreateTemplate(string name, sbyte maxTemperatureThreshold, sbyte minTemperatureThreshold, sbyte maxHumidityThreshold, sbyte minHumidityThreshold, int? maxOxygenThreshold, int? minCarbonDioxideThreshold, int? maxCarbonDioxideThreshold, int? minOxygenThreshold, int? minSulfurDioxideThreshold, int? maxSulfurDioxideThreshold, int? minEthyleneThreshold, int? maxEthyleneThreshold, int? minAmmoniaThreshold, int? maxAmmoniaThreshold)
		{
			var template = new Template(
				name,
				maxTemperatureThreshold,
				minTemperatureThreshold,
				maxHumidityThreshold,
				minHumidityThreshold,
				maxOxygenThreshold,
				minCarbonDioxideThreshold,
				maxCarbonDioxideThreshold,
				minOxygenThreshold,
				minSulfurDioxideThreshold,
				maxSulfurDioxideThreshold,
				minEthyleneThreshold,
				maxEthyleneThreshold,
				minAmmoniaThreshold,
				maxAmmoniaThreshold
			);

			await templateRepository.Add(template);
			await unitOfWork.CompleteAsync();
			return template;
		}

		public async Task<Template?> GetTemplate(int templateId)
		{
			return await templateRepository.GetById(templateId);
		}

		public async Task<IEnumerable<Template>> GetTemplates()
		{
			return await templateRepository.GetAll();
		}
	}
}