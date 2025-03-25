using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.MedicalCenters_Interface
{
    public interface IMedicalCenterRepository
    {
        Task<List<MedicalCenter>> GetAllmedicalCentersAsync();
        Task<MedicalCenter> CreateMedicalCenterAsync(MedicalCenter medicalCenter);
        Task<MedicalCenter> GetmedicalCenterById(int id);
        Task<MedicalCenter> GetmedicalCenterByName(string name);
    }
}
