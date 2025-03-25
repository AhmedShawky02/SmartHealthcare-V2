using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.AwarenessVideos_Interface;
using SmartHealthcare.Interfaces.Booking_Interface;
using SmartHealthcare.Interfaces.Departments_Interface;
using SmartHealthcare.Interfaces.Diseases_Interface;
using SmartHealthcare.Interfaces.Doctors_Interface;
using SmartHealthcare.Interfaces.Helps_Interface;
using SmartHealthcare.Interfaces.MedicalCenters_Interface;
using SmartHealthcare.Interfaces.Nurses_Interface;
using SmartHealthcare.Interfaces.Reviews_Interface;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Models;
using SmartHealthcare.Repositories.AwarenessVideos_Repository;
using SmartHealthcare.Repositories.Booking_Repository;
using SmartHealthcare.Repositories.Departments_Repository;
using SmartHealthcare.Repositories.Diseases_Repository;
using SmartHealthcare.Repositories.Doctors_Repository;
using SmartHealthcare.Repositories.Helps_Repository;
using SmartHealthcare.Repositories.MedicalCenters_Repository;
using SmartHealthcare.Repositories.Nurses_Repository;
using SmartHealthcare.Repositories.Reviews_Repository;
using SmartHealthcare.Repositories.Users_Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HealthcareDbContext>(option =>
    option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
var smtpOptions = builder.Configuration.GetSection("Smtp").Get<SmtpOptions>();

builder.Services.AddSingleton(smtpOptions!);
builder.Services.AddSingleton(jwtOptions!);

builder.Services.AddAuthentication()
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
    {
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions!.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey))
        };
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHashRepository, PasswordHashRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IDiseasesRepository, DiseasesRepository>();
builder.Services.AddScoped<IAwarenessVideoRepository, AwarenessVideoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:5173") 
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");


app.UseAuthorization();

app.MapControllers();

app.Run();
