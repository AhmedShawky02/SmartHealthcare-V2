using SmartHealthcare.Dtos.DepartmentsDto;
using SmartHealthcare.Models;
using System.Numerics;

namespace SmartHealthcare.Mapping
{
    public static class ToDepartmentDto
    {
        public static DepartmentDto ToDepartmentDtoConversion(this Department department)
        {
            return new DepartmentDto()
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Picture = department.Picture
            };
        }

        public static IEnumerable<DepartmentDto> ToDepartmentDtoConversion(this IEnumerable<Department> department)
        {
            return department.Select(department => department.ToDepartmentDtoConversion());
        }

    }
}
