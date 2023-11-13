using yad2_back.Models;

namespace yad2_back.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> IsEmailAlreadyExist(string email);
        Task<UserDTOModel?> SignUp(SignupModel signupModel);
        Task<UserDTOModel?> SignIn(SigninModel signinModel);
        Task<UserDTOModel?> GetUserById(string userId);
    }
}
