using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Models.Entities;

namespace DittoBox.API.AccountSubscription.Domain.Models.Aggregates
{
    public class Account(int id, string businessName, string bussinessId, int representativeId, int subscriptionId)
    {
        public int Id { get; set; } = id;
        public string BusinessName { get; set; } = businessName;
        public string BussinessId { get; set; } = bussinessId;
        public int RepresentativeId { get; set; } = representativeId;
        public int SubscriptionId { get; set; } = subscriptionId;

        public void UpdateBusinessInformation(string businessName, string businessId, int representativeId)
        {
            BusinessName = businessName;
            BussinessId = businessId;
            RepresentativeId = representativeId;
        }
    }
}
