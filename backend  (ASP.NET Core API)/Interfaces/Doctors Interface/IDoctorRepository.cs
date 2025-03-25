using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Doctors_Interface
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctorAsync(Doctor doctor);

        Task<List<Doctor>> GetDoctorsByDepartmentId(int id);
    }
}
