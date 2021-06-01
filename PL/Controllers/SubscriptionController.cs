using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Entities;
using DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.ViewModels.Subscription;

namespace PL.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;

        public SubscriptionController(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult UserSubscription(string id)
        {
            Console.WriteLine(id);
            var userId = id;
            var user = _db.Users.Where(u => u.Id == userId)
                .Include(u => u.Subscriptions)
                .ThenInclude(s => s.SubscriptionType)
                .Include(u => u.Subscriptions)
                .ThenInclude(s => s.SubscriptionStatus)
                .FirstOrDefault();
            Subscription subscription = null;
            if (user is null)
                return NotFound();
            else if (user.Subscriptions != null)
                subscription = user.Subscriptions
                    .FirstOrDefault(s => s.SubscriptionStatus.Description == SubscriptionStatusEnums.Current);
            var model = new SubscriptionViewModel
            {
                Subscription = subscription,
                UserId = userId
            };
            return View(model);
        }

        public IActionResult Home()
        {
            var subscriptionTypes = _db.SubscriptionTypes
                .Include(st => st.SubscriptionOptions)
                .Where(st => st.Description != SubscriptionTypeEnums.Free);
            var model = new SubscriptionsViewModel
            {
                UserId = _userManager.GetUserId(User),
                SubscriptionTypes = subscriptionTypes
            };
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult SubscriptionPage(string id)
        {
            var model = GetSubscription(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubscriptionPage(string id, string name)
        {
            var model = GetSubscription(id);
            var paymentPassed = Services.GetPaymentResponse();
            if (!paymentPassed)
                model.Message = "Ваш платеж не прошел";
            else
            {
                var user = await _userManager.GetUserAsync(User);
                var subscriptionStatus = _db.SubscriptionStatuses
                    .FirstOrDefault(ss => ss.Description == SubscriptionStatusEnums.Current);

                var pastSubscription = _db.User.Where(u => u.Id == user.Id)
                    .Include(u => u.Subscriptions)
                    .ThenInclude(s => s.SubscriptionStatus)
                    .FirstOrDefault()
                    ?.Subscriptions
                    .FirstOrDefault(s => s.SubscriptionStatus.Description == SubscriptionStatusEnums.Current);
                if (pastSubscription != null)
                {
                    var subscriptionStatusPast = _db.SubscriptionStatuses
                        .FirstOrDefault(ss => ss.Description == SubscriptionStatusEnums.Past);
                    pastSubscription.SubscriptionStatus = subscriptionStatusPast;
                    _db.Update(pastSubscription);
                }

                var subscription = Services
                    .GetSubscriptionForUser(model.SubscriptionType, user, subscriptionStatus);
                _db.Subscriptions.Add(subscription);
                await _db.SaveChangesAsync();
                return RedirectToAction("UserSubscription", "Subscription", new {id = user.Id});
            }

            return View(model);
        }

        private SubscriptionPageViewModel GetSubscription(string id)
        {
            var subscriptionType = _db.SubscriptionTypes
                .Where(st => st.Id == id)
                .Include(st => st.SubscriptionOptions)
                .FirstOrDefault();
            var userId = _userManager.GetUserId(User);
            var existsSubscription = _db.User.Where(u => u.Id == userId)
                .Include(u => u.Subscriptions)
                .ThenInclude(s => s.SubscriptionStatus)
                .FirstOrDefault()
                .Subscriptions
                .Any(s => s.SubscriptionStatus.Description == SubscriptionStatusEnums.Current);
            var model = new SubscriptionPageViewModel
            {
                SubscriptionType = subscriptionType,
                UserId = userId,
                ExistsSubcription = existsSubscription
            };
            return model;
        }
    }
}
