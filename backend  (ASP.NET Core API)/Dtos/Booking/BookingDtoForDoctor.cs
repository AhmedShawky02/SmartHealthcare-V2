using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Dtos.Booking
{
    public class BookingDtoForDoctor
    {
        public int BookingDoctorId { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string DoctorName { get; set; }
    }
}
