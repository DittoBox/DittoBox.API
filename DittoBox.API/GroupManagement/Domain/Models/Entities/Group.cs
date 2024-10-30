﻿using DittoBox.API.GroupManagement.Domain.Models.ValueObject;

namespace DittoBox.API.GroupManagement.Domain.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Location Location { get; set; }
        public int AccountId { get; set; }
        public FacilityType FacilityType { get; }
        public int LocationId { get; set; }

        public Group(){}

        public Group(int accountId, string name, Location location, FacilityType facilityType)
        {
            AccountId = accountId;
            Name = name;
            Location = location;
            FacilityType = facilityType;
        }

        public void UpdateGroupLocation(Location location)
        {
            Location = location;
        }

        public void UpdateGroupName(string name)
        {
            Name = name;
        }
    }
}