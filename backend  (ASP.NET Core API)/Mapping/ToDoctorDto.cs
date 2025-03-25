using SmartHealthcare.Dtos.DoctorsDto;
using SmartHealthcare.Models;

namespace SmartHealthcare.Mapping
{
    public static class ToDoctorDto
    {
        public static DoctorDto ToDoctorDtoConversion(this Doctor doctor)
        {
            return new DoctorDto()
            {
                DoctorId = doctor.DoctorId,
                Name = doctor.Name,
                Info = doctor.Info,
                ProfilePicture = doctor.ProfilePicture,
                AvailableTime = doctor.AvailableTime,
                CenterName = doctor.Center.Name,
                DepartmentName = doctor.Department.Name,
                rating = doctor.Reviews.Any() ? (double?)Math.Round(Convert.ToDecimal(doctor.Reviews.Average(r => r.Rating)), 2) : 0
            };
        }

        public static IEnumerable<DoctorDto> ToDoctorDtoConversion(this IEnumerable<Doctor> doctor)
        {
            return doctor.Select(doctor => doctor.ToDoctorDtoConversion());
        }

    }
}
