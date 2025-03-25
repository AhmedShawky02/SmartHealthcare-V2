using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Booking_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.Booking_Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HealthcareDbContext _context;

        public BookingRepository(HealthcareDbContext context)
        {
            _context = context;
        }
        public async Task<BookingDoctor> CreateBookingForDoctorAsync(BookingDoctor bookingDoctor)
        {
            await _context.BookingDoctors.AddAsync(bookingDoctor);
            await _context.SaveChangesAsync();
            return bookingDoctor;
        }

        public async Task<List<BookingDoctor>> GetAllBookingsForDoctor()
        {
            return await _context.BookingDoctors.ToListAsync();

        }

        public async Task<BookingNurse> CreateBookingForNurseAsync(BookingNurse bookingNurse)
        {
            await _context.BookingNurses.AddAsync(bookingNurse);
            await _context.SaveChangesAsync();
            return bookingNurse;
        }

        public async Task<List<BookingNurse>> GetAllBookingsForNurse()
        {
            return await _context.BookingNurses.ToListAsync();
        }

        public async Task<List<BookingDoctor>> GetAllDoctorBookingsForUser(int userId)
        {
            return await _context.BookingDoctors.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<BookingNurse>> GetAllNurseBookingsForUser(int userId)
        {
            return await _context.BookingNurses.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<BookingDoctor> GetBookingDoctorById(int id)
        {
            var booking = await _context.BookingDoctors.FirstOrDefaultAsync(x => x.BookingDoctorId == id);
            if (booking == null)
            {
                return null;
            }
            return booking;
        }

        public async Task<bool> DeleteBoking(BookingDoctor booking)
        {
            _context.BookingDoctors.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBokingNurse(BookingNurse booking)
        {
            _context.BookingNurses.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BookingNurse> GetBookingNurseById(int id)
        {
            var booking = await _context.BookingNurses.FirstOrDefaultAsync(x => x.BookingNurseId == id);
            if (booking == null)
            {
                return null;
            }
            return booking;
        }
    }
}
