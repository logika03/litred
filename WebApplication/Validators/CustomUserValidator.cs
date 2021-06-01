using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication.Models;

namespace WebApplication
{
    public class CustomUserValidator:IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            return Task.FromResult(errors.Count == 0
                ? IdentityResult.Success
                : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
