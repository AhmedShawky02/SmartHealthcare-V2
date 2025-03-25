using SmartHealthcare.Dtos.NursesDto;
using SmartHealthcare.Models;
using System.Numerics;

namespace SmartHealthcare.Mapping
{
    public static class ToNurseDto
    {
        public static NurseDto ToNurseDtoConversion(this Nurse nurse)
        {
            return new NurseDto()
            {
                NurseId = nurse.NurseId,
                Name = nurse.Name,
                Info = nurse.Info,
                ProfilePicture = nurse.ProfilePicture,
                Age = nurse.Age,
                CenterName = nurse.Center.Name,
            };
        }

        public static IEnumerable<NurseDto> ToNurseDtoConversion(this IEnumerable<Nurse> nurse)
        {
            return nurse.Select(nurse => nurse.ToNurseDtoConversion());
        }

    }
}
