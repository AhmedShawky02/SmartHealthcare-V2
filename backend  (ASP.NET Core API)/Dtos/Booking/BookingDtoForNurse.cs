using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Dtos.Booking
{
    public class BookingDtoForNurse
    {
        public int BookingNurseId { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string NurseName { get; set; }
    }
}
