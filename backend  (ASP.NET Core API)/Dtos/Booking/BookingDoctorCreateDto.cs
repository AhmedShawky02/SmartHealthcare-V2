using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Dtos.Booking
{
    public class BookingDoctorCreateDto
    {
        [Required]
        public DateTime Date { get; set; }
        //public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int DoctorId { get; set; }
    }
}
