using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Models;
using SmartHealthcare.Repositories.Helps_Repository;

namespace SmartHealthcare.Repositories.Users_Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthcareDbContext _context;
        private readonly SmtpOptions _smtp;

        public UserRepository(HealthcareDbContext context , SmtpOptions smtp)
        {
            _context = context;
            _smtp = smtp;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByName(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        private string _createRandom5Number()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 100000);
            return randomNumber.ToString();
        }

        private async Task GenerateResetToken(User user)
        {
            var randomOTP = _createRandom5Number();
            user.ForgetToken = randomOTP;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SendEmailAsync(string email)
        {
            var user = await GetUserByEmail(email);

            if (user == null)
                return false;

            await GenerateResetToken(user);

            try
            {
                string otp = user.ForgetToken!;

                var sender = new MimeMessage();
                sender.From.Add(MailboxAddress.Parse(_smtp.EmailSend));
                sender.To.Add(MailboxAddress.Parse(user.Email));
                sender.Subject = "Password Reset OTP";

                string htmlContent = $@"
                <html>
                    <body style='font-family: Arial, sans-serif; text-align: center;'>
                        <h2 style='color: #007bff;'>Password Reset Request</h2>
                        <p>Hello <strong>{user.Name}</strong>,</p>
                        <p>You have requested to reset your password. Use the following OTP to proceed:</p>
                        <h3 style='background-color: #f8f9fa; padding: 10px; display: inline-block; border-radius: 5px;'>
                            {otp}
                        </h3>
                        <br>
                        <p style='color: #6c757d; font-size: 12px;'>Best regards, <br>Ahmed Shawky</p>
                    </body>
                </html>";

                var bodyBuilder = new BodyBuilder { HtmlBody = htmlContent };
                sender.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_smtp.SmtpServer, _smtp.Port, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_smtp.EmailSend, _smtp.AppPassword);
                smtp.Send(sender);
                smtp.Disconnect(true);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetUserByToken(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ForgetToken == token);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
