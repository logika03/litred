﻿using DAL.Entities;

namespace PL.ViewModels.Subscription
{
    public class SubscriptionPageViewModel
    {
        public SubscriptionType SubscriptionType { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public bool ExistsSubcription { get; set; }
    }
}
