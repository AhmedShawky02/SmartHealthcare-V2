using SmartHealthcare.Dtos.DiseasesDto;
using SmartHealthcare.Models;

namespace SmartHealthcare.Mapping
{
    public static class ToDiseasesDto
    { 
        public static DiseasesDto ToDiseasesDtoConversion(this Disease disease)
        {
            return new DiseasesDto()
            {
                 DiseaseId = disease.DiseaseId,
                 Name = disease.Name,
                 UserId = disease.UserId,
                 Symptom = disease.DiseaseSymptoms.Select(x => new SymptomDto()
                 {
                     SymptomId = x.Symptom.SymptomId,
                     Name = x.Symptom.Name
                 }).ToList(),
            };
        }

        public static IEnumerable<DiseasesDto> ToDiseasesDtoConversion(this IEnumerable<Disease> disease)
        {
            return disease.Select(disease => disease.ToDiseasesDtoConversion());
        }
    }
}
