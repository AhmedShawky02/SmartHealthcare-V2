using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Users_Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByName(string name);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> SendEmailAsync(string email);
        Task<User> GetUserById(int id);
        Task<User> GetUserByToken(string token);

    }
}
