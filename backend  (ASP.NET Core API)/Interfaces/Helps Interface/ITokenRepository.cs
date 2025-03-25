using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Helps_Interface
{
    public interface ITokenRepository
    {
        Task<string> CreateToken(User user);
    }
}
