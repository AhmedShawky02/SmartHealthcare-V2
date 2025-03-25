using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Dtos.Booking;
using SmartHealthcare.Dtos.DoctorsDto;
using SmartHealthcare.Interfaces.Booking_Interface;
using SmartHealthcare.Interfaces.Doctors_Interface;
using SmartHealthcare.Interfaces.Nurses_Interface;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;
using System.Numerics;
using System.Security.Claims;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly INurseRepository _nurseRepo;

        public BookingController(IBookingRepository bookingRepo,
            IUserRepository userRepo,
            IDoctorRepository doctorRepo,
            INurseRepository nurseRepo)
        {
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
            _doctorRepo = doctorRepo;
            _nurseRepo = nurseRepo;
        }

        [HttpGet("GetAllBookingsForDoctor")]
        public async Task<IActionResult> GetAllBookingsForDoctor()
        {
            try
            {
                var bookings = await _bookingRepo.GetAllBookingsForDoctor();

                if (!bookings.Any())
                {
                    return NotFound("No bookings found.");
                }

                var bookingsDto = bookings.ToBookingsDtoConversion();
                return Ok(bookingsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("User")]
        [Authorize]
        public async Task<IActionResult> GetAllBookingsForUser()
        {
            try
            {

                var userEmailClaim = User.FindFirstValue(ClaimTypes.Email);
                if (userEmailClaim == null)
                {
                    return Unauthorized("Invalid token");
                }

                var user = await _userRepo.GetUserByEmail(userEmailClaim);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var doctorBookings = await _bookingRepo.GetAllDoctorBookingsForUser(user.UserId);
                var nurseBookings = await _bookingRepo.GetAllNurseBookingsForUser(user.UserId);

                if (!doctorBookings.Any() && !nurseBookings.Any())
                {
                    return NotFound("No Bookings found.");
                }

                var doctorBookingsDto = doctorBookings.ToBookingsDtoConversion();
                var nurseBookingsDto = nurseBookings.ToBookingsDtoConversion();

                var result = new
                {
                    DoctorBookings = doctorBookingsDto,
                    NurseBookings = nurseBookingsDto
                };

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateBookingForDoctor")]
        public async Task<IActionResult> CreateBookingForDoctor([FromBody] BookingDoctorCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingUser = await _userRepo.GetUserByName(createDto.UserName);
                if (existingUser == null)
                {
                    return NotFound("User not Found.");
                }

                var existingDoctor = await _doctorRepo.GetDoctorById(createDto.DoctorId);
                if (existingDoctor == null)
                {
                    return NotFound("Doctor not Found.");
                }

                if (createDto.Date <= DateTime.Now)
                {
                    return BadRequest("Cannot select a past date or today's date for booking.");
                }

                var booking = new BookingDoctor()
                {
                    Date = createDto.Date,
                    UserId = existingUser.UserId,
                    DoctorId = createDto.DoctorId
                };

                await _bookingRepo.CreateBookingForDoctorAsync(booking);

                return StatusCode(201, new { id = booking.BookingDoctorId, message = "Booking added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllBookingsForNurse")]
        public async Task<IActionResult> GetAllBookingsForNurse()
        {
            try
            {
                var bookings = await _bookingRepo.GetAllBookingsForNurse();

                if (!bookings.Any())
                {
                    return NotFound("No bookings found.");
                }

                var bookingsDto = bookings.ToBookingsDtoConversion();
                return Ok(bookingsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateBookingForNurse")]
        public async Task<IActionResult> CreateBookingForNurse([FromBody] BookingNurseCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingUser = await _userRepo.GetUserByName(createDto.UserName);
                if (existingUser == null)
                {
                    return NotFound("User not Found.");
                }

                var existingNurse = await _nurseRepo.GetNurseById(createDto.NurseId);
                if (existingNurse == null)
                {
                    return NotFound("Nurse not Found.");
                }

                if (createDto.Date <= DateTime.UtcNow)
                {
                    return BadRequest("Error: Cannot select a past date or today's date for booking.");
                }

                var booking = new BookingNurse()
                {
                    Date = createDto.Date,
                    UserId = existingUser.UserId,
                    NurseId = createDto.NurseId,
                };

                await _bookingRepo.CreateBookingForNurseAsync(booking);

                return StatusCode(201, new { id = booking.BookingNurseId, message = "Booking added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingForUser([FromRoute] int id)
        {
            try
            {
                var booking = await _bookingRepo.GetBookingDoctorById(id);
                if (booking == null)
                {
                    return NotFound("Booking not Found.");
                }

                var isDeleted = await _bookingRepo.DeleteBoking(booking);
                if (!isDeleted)
                {
                    return BadRequest("Failed to delete booking.");
                }

                return Ok("Booking deleted successfully.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteNurse/{id}")]
        public async Task<IActionResult> DeleteBookingNurseForUser([FromRoute] int id)
        {
            try
            {
                var booking = await _bookingRepo.GetBookingNurseById(id);
                if (booking == null)
                {
                    return NotFound("Booking not Found.");
                }

                var isDeleted = await _bookingRepo.DeleteBokingNurse(booking);
                if (!isDeleted)
                {
                    return BadRequest("Failed to delete booking.");
                }

                return Ok("Booking deleted successfully.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
