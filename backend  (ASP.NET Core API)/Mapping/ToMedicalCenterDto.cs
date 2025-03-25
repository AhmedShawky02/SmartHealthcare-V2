using SmartHealthcare.Dtos.MedicalCenterDto;
using SmartHealthcare.Models;

namespace SmartHealthcare.Mapping
{
    public static class ToMedicalCenterDto
    {
        public static MedicalCenterDto ToMedicalCenterDtoConversion(this MedicalCenter medicalCenter)
        {
            return new MedicalCenterDto()
            {
                CenterId = medicalCenter.CenterId,
                Name = medicalCenter.Name,
                Location = medicalCenter.Location,
            };
        }

        public static IEnumerable<MedicalCenterDto> ToMedicalCenterDtoConversion(this IEnumerable<MedicalCenter> medicalCenter)
        {
            return medicalCenter.Select(medicalCenter => medicalCenter.ToMedicalCenterDtoConversion());
        }
    }
}
