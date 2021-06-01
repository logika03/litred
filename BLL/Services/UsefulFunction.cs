using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class UsefulFunction : IActionFilter
    {
        private readonly ILogger _logger;

        public UsefulFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UsefulFunction>();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Before action");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           _logger.LogInformation("After");
        }
    }
}
