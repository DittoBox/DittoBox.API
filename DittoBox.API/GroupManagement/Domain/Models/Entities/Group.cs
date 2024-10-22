using DittoBox.API.GroupManagement.Domain.Models.ValueObject;

namespace DittoBox.API.GroupManagement.Domain.Models.Entities
{
    public class Group (
        string name,
        string country,
        string city,
        FacilityType facilityType
    )
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public Location Location { get; set; } = new Location(country, city);
        public int AccountId { get; set; }
        public int FacilityType { get; set; } = (int)facilityType;

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
