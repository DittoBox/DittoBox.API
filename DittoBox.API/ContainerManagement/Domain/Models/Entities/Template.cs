namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
	public class Template
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		// Temperature in a range from -127 to 127 degrees Celsius
		public sbyte MaxTemperatureThreshold { get; set; }
		public sbyte MinTemperatureThreshold { get; set; }

		// Humidity in a range from 0 to 100%
		public float MaxHumidityThreshold { get; set; }
		public float MinHumidityThreshold { get; set; }

		// Gases measured in PPM (particles per million)
		public int? MinOxygenThreshold { get; set; }
		public int? MaxOxygenThreshold { get; set; }
		public int? MinCarbonDioxideThreshold { get; set; }
		public int? MaxCarbonDioxideThreshold { get; set; }
		public int? MinSulfurDioxideThreshold { get; set; }
		public int? MaxSulfurDioxideThreshold { get; set; }
		public int? MinEthyleneThreshold { get; set; }
		public int? MaxEthyleneThreshold { get; set; }
		public int? MinAmmoniaThreshold { get; set; }
		public int? MaxAmmoniaThreshold { get; set; }
		public Template() { }
		public Template(
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
			int? maxAmmoniaThreshold
		)
		{
			Name = name;
			MaxTemperatureThreshold = maxTemperatureThreshold;
			MinTemperatureThreshold = minTemperatureThreshold;
			MaxHumidityThreshold = maxHumidityThreshold;
			MinHumidityThreshold = minHumidityThreshold;
			MinOxygenThreshold = minOxygenThreshold;
			MaxOxygenThreshold = maxOxygenThreshold;
			MinCarbonDioxideThreshold = minCarbonDioxideThreshold;
			MaxCarbonDioxideThreshold = maxCarbonDioxideThreshold;
			MinSulfurDioxideThreshold = minSulfurDioxideThreshold;
			MaxSulfurDioxideThreshold = maxSulfurDioxideThreshold;
			MinEthyleneThreshold = minEthyleneThreshold;
			MaxEthyleneThreshold = maxEthyleneThreshold;
			MinAmmoniaThreshold = minAmmoniaThreshold;
			MaxAmmoniaThreshold = maxAmmoniaThreshold;
		}
	}
}
