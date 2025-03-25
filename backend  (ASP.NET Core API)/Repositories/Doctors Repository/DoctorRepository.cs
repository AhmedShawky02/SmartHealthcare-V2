using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Doctors_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.Doctors_Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealthcareDbContext _context;

        public DoctorRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);
            if (doctor == null)
            {
                return null;
            }
            return doctor;
        }

        public async Task<List<Doctor>> GetDoctorsByDepartmentId(int id)
        {
            return await _context.Doctors.Where(d => d.DepartmentId == id).ToListAsync();
        }
    }
}
