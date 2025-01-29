using testapi.DTO;

namespace testapi.Services
{
    public interface IAdminService
    {
        Task<User> Register(UserRegister user);
        Task<UserLogin> Login(string username, string password);

    }
}