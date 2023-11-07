using Microsoft.AspNetCore.Identity;

namespace yad2_back.Models
{
    public class UserPasswordValidator : IPasswordValidator<UserModel>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<UserModel> manager, UserModel user, string password)
        {
            // Customize the password validation logic here
            if (!password.Any(char.IsLower) && !password.Any(char.IsUpper))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordRequiresUppercaseOrLowercase",
                    Description = "The password must contain either an uppercase or a lowercase letter."
                }));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
