using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
    public class Container
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AccountId { get; set; }
        public ContainerSize ContainerSize { get; set; } = ContainerSize.Small;
        public int LastKnownHealthStatus { get; private set; } = 0;
        public DateTime? LastKnownHealthStatusReport { get; private set; } = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        public int LastKnownContainerStatus { get; set; } = 0;
        public DateTime LastKnownContainerStatusReport { get; set; } = new DateTime();


        public void UpdateHealthStatus(HealthStatus status)
        {
            LastKnownHealthStatus = (int)status;
            LastKnownHealthStatusReport = DateTime.UtcNow;
            LastSync = DateTime.UtcNow;
        }

        public void UpdateContainerStatus(ContainerStatus status)
        {
            LastKnownContainerStatus = (int)status;
            LastKnownContainerStatusReport = DateTime.UtcNow;
            LastSync = DateTime.UtcNow;
        }

        /// <summary>
        /// Manual regulation of container inner conditions. <paramref name="containerTarget"/> is the target to regulate, <paramref name="value"/> is the value to regulate.
        /// </summary>
        /// <param name="containerTarget"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TriggerRegulation(TargetType containerTarget, sbyte value)
        {
            if (LastKnownHealthStatus == (int)HealthStatus.Critical)
            {
                // Trigger regulation
                return true;
            }
            return false;
        }

        public void UpdateConditions(ContainerConditions newConditions)
        {
            ContainerConditions = newConditions;
        }

        public void UpdateMetrics(double temperature, double humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
            LastSync = DateTime.UtcNow;
        }

    }
}
