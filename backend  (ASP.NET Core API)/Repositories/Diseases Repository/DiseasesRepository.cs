using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Diseases_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.Diseases_Repository
{
    public class DiseasesRepository : IDiseasesRepository
    {
        private readonly HealthcareDbContext _context;

        public DiseasesRepository(HealthcareDbContext context)
        {
            _context = context;
        }
        public async Task<Disease> CreateDiseasesAsync(Disease disease)
        {
            await _context.Diseases.AddAsync(disease);
            await _context.SaveChangesAsync();
            return disease;
        }

        public async Task<DiseaseSymptom> CreateDiseaseSymptomAsync(DiseaseSymptom diseaseSymptom)
        {
            await _context.DiseaseSymptoms.AddAsync(diseaseSymptom);
            await _context.SaveChangesAsync();
            return diseaseSymptom;
        }

        public async Task<Symptom> CreateSymptomAsync(Symptom symptom)
        {
            await _context.Symptoms.AddAsync(symptom);
            await _context.SaveChangesAsync();
            return symptom;
        }

        public async Task<List<Disease>> GetAllDiseaseAsync()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease> GetDiseaseById(int id)
        {
            var disease = await _context.Diseases.FirstOrDefaultAsync(x => x.DiseaseId == id);
            if (disease == null)
            {
                return null;
            }
            return disease;
        }

        public async Task<DiseaseSymptom> GetDiseaseSymptomById(int diseaseId, int symptomId)
        {
            var disease = await _context.DiseaseSymptoms
                .FirstOrDefaultAsync(ds => ds.DiseaseId == diseaseId && ds.SymptomId == symptomId);
            if (disease == null)
            {
                return null;
            }
            return disease;
        }

        public async Task<Symptom> GetSymptomById(int id)
        {
            var symptom = await _context.Symptoms.FirstOrDefaultAsync(x => x.SymptomId == id);
            if (symptom == null)
            {
                return null;
            }
            return symptom;
        }


    }
}
