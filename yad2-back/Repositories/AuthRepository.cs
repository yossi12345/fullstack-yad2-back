using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using yad2_back.Models;

namespace yad2_back.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthRepository(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<bool> IsEmailAlreadyExist(string email) 
        {
            return await _userManager.FindByEmailAsync(email)!=null;
        }
        public async Task<UserDTOModel?> SignUp(SignupModel signupModel)
        {
            UserModel user = new()
            {
                UserName = signupModel.Mail,
                Email = signupModel.Mail,
                FirstName = signupModel.FirstName,
                LastName = signupModel.LastName,
                PhoneNumber = signupModel.Phone
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, signupModel.Password);
            if (!identityResult.Succeeded)
            {
                return null;
            }
            return Mapper.UserDAOToDTO(user,CreateNewToken(user.Id));
        }
        public async Task<UserDTOModel?> SignIn(SigninModel signinModel)
        {
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(signinModel.Mail, signinModel.Password, false, false);
            if (!signInResult.Succeeded)
            {
                return null;
            }
            UserModel user = await _userManager.Users.
                Include(u=>u.FavoriteApartments).
                Include(u=>u.ApartmentForSelling).
                FirstAsync(u=>u.Email==signinModel.Mail);
            return Mapper.UserDAOToDTO(user, CreateNewToken(user.Id));
        }
        public async Task<UserDTOModel?> GetUserById(string userId)
        {
            UserModel? user=await _userManager.Users.
                Include(u => u.FavoriteApartments).
                Include(u => u.ApartmentForSelling).
                FirstOrDefaultAsync(u => u.Id == userId);
            return user==null?null:Mapper.UserDAOToDTO(user);
        }
        private string CreateNewToken(string id)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authSignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
