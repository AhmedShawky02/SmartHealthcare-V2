using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.MedicalCenters_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.MedicalCenters_Repository
{
    public class MedicalCenterRepository : IMedicalCenterRepository
    {
        private readonly HealthcareDbContext _context;

        public MedicalCenterRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalCenter> CreateMedicalCenterAsync(MedicalCenter medicalCenter)
        {
            await _context.MedicalCenters.AddAsync(medicalCenter);
            await _context.SaveChangesAsync();
            return medicalCenter;
        }

        public async Task<List<MedicalCenter>> GetAllmedicalCentersAsync()
        {
            return await _context.MedicalCenters.ToListAsync();
        }

        public async Task<MedicalCenter> GetmedicalCenterById(int id)
        {
            var medicalCenter = await _context.MedicalCenters.FirstOrDefaultAsync(x => x.CenterId == id);
            if (medicalCenter == null)
            {
                return null;
            }
            return medicalCenter;
        }

        public async Task<MedicalCenter> GetmedicalCenterByName(string name)
        {
            var medicalCenter = await _context.MedicalCenters.FirstOrDefaultAsync(x => x.Name == name);
            if (medicalCenter == null)
            {
                return null;
            }
            return medicalCenter;
        }


    }
}
