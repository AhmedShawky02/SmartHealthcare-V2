using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Departments_Interface
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentById(int id);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> GetDepartmentByName(string name);

    }
}
