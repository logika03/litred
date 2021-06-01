using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BLL.Jobs
{
    public class SubscriptionCheckerJob : CronJobService
    {
        private readonly ILogger<SubscriptionCheckerJob> _logger;

        public SubscriptionCheckerJob(IScheduleConfig<SubscriptionCheckerJob> config,
            ILogger<SubscriptionCheckerJob> logger, IServiceScopeFactory scopeFactory)
            : base(config.CronExpression, config.TimeZoneInfo, scopeFactory)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SubscriptionCheckerJob starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} SubscriptionCheckerJob is working.");
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            var subscriptions = db.Subscriptions
                .Include(s => s.SubscriptionStatus);
            var subscriptionStatusPast = db.SubscriptionStatuses
                .FirstOrDefault(ss => ss.Description == SubscriptionStatusEnums.Past);
            subscriptions = Services.Services.ChangeSubscriptionStatusOnPast(subscriptions, subscriptionStatusPast);
            db.SaveChanges();

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SubscriptionCheckerJob is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}