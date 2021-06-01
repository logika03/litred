using System.Collections.Generic;
using DAL.Entities;

namespace PL.ViewModels.Subscription
{
    public class SubscriptionsViewModel
    {
        public IEnumerable<SubscriptionType> SubscriptionTypes { get; set; }
        public string UserId { get; set; }
    }
}
