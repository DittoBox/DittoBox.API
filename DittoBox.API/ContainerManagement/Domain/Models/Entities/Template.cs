namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public sbyte MaxTemperatureThreshold { get; set; }
        public sbyte MinTemperatureThreshold { get; set; }
        public sbyte MaxHumidityThreshold { get; set; }
        public sbyte MinHumidityThreshold { get; set; }
        bool IsGasDetectionEnabled { get; set; }
        public int AccountId { get; set; }

        public Template(string name, sbyte maxTemperatureThreshold, sbyte minTemperatureThreshold, sbyte maxHumidityThreshold, sbyte minHumidityThreshold, bool isGasDetectionEnabled, int accountId)
        {
            Name = name;
            MaxTemperatureThreshold = maxTemperatureThreshold;
            MinTemperatureThreshold = minTemperatureThreshold;
            MaxHumidityThreshold = maxHumidityThreshold;
            MinHumidityThreshold = minHumidityThreshold;
            IsGasDetectionEnabled = isGasDetectionEnabled;
            AccountId = accountId;
        }

        public void Update(string name, sbyte maxTemperatureThreshold, sbyte minTemperatureThreshold, sbyte maxHumidityThreshold, sbyte minHumidityThreshold, bool isGasDetectionEnabled)
        {
            Name = name;
            MaxTemperatureThreshold = maxTemperatureThreshold;
            MinTemperatureThreshold = minTemperatureThreshold;
            MaxHumidityThreshold = maxHumidityThreshold;
            MinHumidityThreshold = minHumidityThreshold;
            IsGasDetectionEnabled = isGasDetectionEnabled;
        }
    }
}
