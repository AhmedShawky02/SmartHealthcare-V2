using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Nurses_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.Nurses_Repository
{
    public class NurseRepository : INurseRepository
    {
        private readonly HealthcareDbContext _context;

        public NurseRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Nurse> CreateNurseAsync(Nurse nurse)
        {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();
            return nurse;
        }

        public async Task<List<Nurse>> GetAllNursesAsync()
        {
            return await _context.Nurses.ToListAsync();
        }

        public async Task<Nurse> GetNurseById(int id)
        {
            var nurse = await _context.Nurses.FirstOrDefaultAsync(x => x.NurseId == id);
            if (nurse == null)
            {
                return null;
            }
            return nurse;
        }
    }
}
