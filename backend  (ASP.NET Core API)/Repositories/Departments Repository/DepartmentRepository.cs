using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Departments_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.Departments_Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HealthcareDbContext _context;

        public DepartmentRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var Department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);

            if (Department == null)
            {
                return null;
            }
            return Department;
        }

        public async Task<Department> GetDepartmentByName(string name)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Name == name);
            if (department == null)
            {
                return null;
            }
            return department;
        }
    }
}
