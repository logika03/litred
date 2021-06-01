using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels.Subscription
{
    public class SubscriptionsViewModel
    {
        public IEnumerable<SubscriptionType> SubscriptionTypes { get; set; }
        public string UserId { get; set; }
    }
}
