using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Models.Entities;

namespace DittoBox.API.AccountSubscription.Domain.Models.Aggregates
{
    public class Account
    {
        public int Id { get; set; }
        private string BusinessName { get; set; }
        private int BussinessId { get; set; }
        private User Representative { get; set; }
        private Subscription Subscription { get; set; }
    }
}
