using DittoBox.API.AccountSubscription.Domain.Models.ValueObjects;

namespace DittoBox.API.AccountSubscription.Domain.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        private SubscriptionTier Tier { get; set; }
        private DateOnly PaymentDate { get; set; }
        private SubscriptionStatus SubscriptionStatus { get; set; }
        private DateOnly LastPaidPeriod { get; set; }
    }
}
