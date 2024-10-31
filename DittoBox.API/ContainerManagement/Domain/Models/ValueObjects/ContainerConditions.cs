namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public class ContainerConditions
    {
        public double MaxTemperature { get; private set; }
        public double MinTemperature { get; private set; }
        public double MaxHumidity { get; private set; }
        public double MinHumidity { get; private set; }

        public double OxygenMin { get; private set; }
        public double OxygenMax { get; private set; }
        public double DioxideMin { get; private set; }
        public double DioxideMax { get; private set; }
        public double EthyleneMin { get; private set; }
        public double EthyleneMax { get; private set; }
        public double AmmoniaMin { get; private set; }
        public double AmmoniaMax { get; private set; }
        public double SulfurDioxideMin { get; private set; }
        public double SulfurDioxideMax { get; private set; }

        public ContainerConditions(
            double minTemp, double maxTemp,
            double minHumidity, double maxHumidity,
            double oxygenMin, double oxygenMax,
            double dioxideMin, double dioxideMax,
            double ethyleneMin, double ethyleneMax,
            double ammoniaMin, double ammoniaMax,
            double sulfurDioxideMin, double sulfurDioxideMax)
        {
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
            MinHumidity = minHumidity;
            MaxHumidity = maxHumidity;
            OxygenMin = oxygenMin;
            OxygenMax = oxygenMax;
            DioxideMin = dioxideMin;
            DioxideMax = dioxideMax;
            EthyleneMin = ethyleneMin;
            EthyleneMax = ethyleneMax;
            AmmoniaMin = ammoniaMin;
            AmmoniaMax = ammoniaMax;
            SulfurDioxideMin = sulfurDioxideMin;
            SulfurDioxideMax = sulfurDioxideMax;
        }
    }
}
