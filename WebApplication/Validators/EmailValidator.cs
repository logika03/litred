using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Validators
{
    public class EmailValidator<TUser> : IUserValidator<TUser>
       where TUser : IdentityUser
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                  TUser user)
        {;
            if (user.Email == null)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                var userExist = manager.FindByEmailAsync(user.Email);
                if (userExist.Result == null)
                {
                    return Task.FromResult(IdentityResult.Success);
                }
            }

            return Task.FromResult(
                     IdentityResult.Failed(new IdentityError
                     {
                         Code = "400",
                         Description = "Аккаунт с такой почтой уже существует"
                     }));
        }
    }
}
