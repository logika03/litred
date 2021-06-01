using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApplication.Enums;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class Services
    {
        public static bool GetPaymentResponse()
        {
            var results = new bool[] {false, true, true, true, true, true, true, true, true, true};
            var rnd = new Random();
            var index = rnd.Next(results.Length);
            return results[index];
        }

        public static Subscription GetSubscriptionForUser(SubscriptionType subscriptionType, User user,
            SubscriptionStatus subscriptionStatus)
        {
            var endDate = DateTime.Now.AddMonths(subscriptionType.MonthCount);
            var subscription = new Subscription
            {
                SubscriptionType = subscriptionType,
                EndDate = endDate,
                SubscriptionStatus = subscriptionStatus,
                User = user
            };
            return subscription;
        }

        public static IIncludableQueryable<Subscription, SubscriptionStatus> ChangeSubscriptionStatusOnPast(
            IIncludableQueryable<Subscription, SubscriptionStatus> subscriptions,
            SubscriptionStatus subscriptionStatusPast)
        {
            var changeSubscriptions = new List<Subscription>();


            foreach (var subscription in subscriptions
                .Where(subscription => subscription.EndDate.Date < DateTime.Now.Date))
            {
                subscription.SubscriptionStatus = subscriptionStatusPast;
            }

            return subscriptions;
        }
    }
}
