using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Diseases_Interface
{
    public interface IDiseasesRepository
    {
        Task<Disease> CreateDiseasesAsync(Disease disease);
        Task<Disease> GetDiseaseById(int id);
        Task<Symptom> CreateSymptomAsync(Symptom symptom);
        Task<Symptom> GetSymptomById(int id);
        Task<DiseaseSymptom> CreateDiseaseSymptomAsync( DiseaseSymptom diseaseSymptom);
        Task<List<Disease>> GetAllDiseaseAsync();
        Task<DiseaseSymptom> GetDiseaseSymptomById(int diseaseId, int symptomId);
    }
}
