using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Nurses_Interface
{
    public interface INurseRepository
    {
        Task<List<Nurse>> GetAllNursesAsync();
        Task<Nurse> GetNurseById(int id);
        Task<Nurse> CreateNurseAsync(Nurse nurse);
    }
}
