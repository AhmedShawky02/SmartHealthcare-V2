using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Booking_Interface
{
    public interface IBookingRepository
    {
        Task<List<BookingDoctor>> GetAllBookingsForDoctor();
        Task<BookingDoctor> CreateBookingForDoctorAsync(BookingDoctor bookingDoctor);
        Task<List<BookingDoctor>> GetAllDoctorBookingsForUser(int userId);
        Task<BookingDoctor> GetBookingDoctorById(int id);
        Task<bool> DeleteBoking(BookingDoctor booking);
        Task<bool> DeleteBokingNurse(BookingNurse booking);

        Task<List<BookingNurse>> GetAllNurseBookingsForUser(int userId);
        Task<List<BookingNurse>> GetAllBookingsForNurse();
        Task<BookingNurse> GetBookingNurseById(int id);
        Task<BookingNurse> CreateBookingForNurseAsync(BookingNurse bookingDoctor);
    }
}
