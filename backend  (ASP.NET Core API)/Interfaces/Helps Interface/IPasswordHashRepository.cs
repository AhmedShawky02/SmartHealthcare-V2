namespace SmartHealthcare.Interfaces.Helps_Interface
{
    public interface IPasswordHashRepository
    {
        string Hash(string password);
        bool Verified(string passwordHash, string password);
    }
}
