﻿using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record ContainerResource(
            int Id, 
            string Name,
            string Description,
            double Temperature,
            double Humidity,
            double? minTemp, double? maxTemp,
            double? minHumidity, double? maxHumidity,
            double? oxygenMin, double? oxygenMax,
            double? dioxideMin, double? dioxideMax,
            double? ethyleneMin, double? ethyleneMax,
            double? ammoniaMin, double? ammoniaMax,
            double? sulfurDioxideMin, double? sulfurDioxideMax,
            string LastKnownHealthStatus,
            string LastKnownContainerStatus,
            DateTime LastSync
        )
    {
        public static ContainerResource FromContainer(Container container)
        {
            return new ContainerResource(
                container.Id, 
                container.Name, 
                container.Description,
                container.Temperature,
                container.Humidity,
                container.ContainerConditions?.MinTemperature,
                container.ContainerConditions?.MaxTemperature,
                container.ContainerConditions?.MinHumidity,
                container.ContainerConditions?.MaxHumidity,
                container.ContainerConditions?.OxygenMin,
                container.ContainerConditions?.OxygenMax,
                container.ContainerConditions?.DioxideMin,
                container.ContainerConditions?.DioxideMax,
                container.ContainerConditions?.EthyleneMin,
                container.ContainerConditions?.EthyleneMax,
                container.ContainerConditions?.AmmoniaMin,
                container.ContainerConditions?.AmmoniaMax,
                container.ContainerConditions?.SulfurDioxideMin,
                container.ContainerConditions?.SulfurDioxideMax,
                ((ContainerStatus)container.LastKnownHealthStatus).ToString(),
                ((HealthStatus)container.LastKnownContainerStatus).ToString(),
                container.LastSync
            );
        }
    }
}