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
        public DateTime LastKnownHealthStatusReport { get; private set; } = new DateTime(1970, 1, 1);
        public int LastKnownContainerStatus { get; set; } = 0;
        public DateTime LastKnownContainerStatusReport { get; set; } = new DateTime();


        public void UpdateHealthStatus(HealthStatus status)
        {
            LastKnownHealthStatus = (int)status;
            LastKnownHealthStatusReport = DateTime.UtcNow;
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




    }
}
