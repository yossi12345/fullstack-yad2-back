namespace yad2_back.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> IsEmailAlreadyExist(string email);
    }
}
