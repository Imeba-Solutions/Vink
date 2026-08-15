using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Backend.Data;
using Backend.Features.Auth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Auth Service
builder.Services.AddScoped<AuthService>();

// Add Feature Services and Repositories
builder.Services.AddScoped<Backend.Features.Roles.Interfaces.IRoleRepository, Backend.Features.Roles.Repositories.RoleRepository>();
builder.Services.AddScoped<Backend.Features.Roles.Interfaces.IRoleService, Backend.Features.Roles.Services.RoleService>();

builder.Services.AddScoped<Backend.Features.Users.Interfaces.IUserRepository, Backend.Features.Users.Repositories.UserRepository>();
builder.Services.AddScoped<Backend.Features.Users.Interfaces.IUserService, Backend.Features.Users.Services.UserService>();

builder.Services.AddScoped<Backend.Features.Patients.Interfaces.IPatientRepository, Backend.Features.Patients.Repositories.PatientRepository>();
builder.Services.AddScoped<Backend.Features.Patients.Interfaces.IPatientService, Backend.Features.Patients.Services.PatientService>();

builder.Services.AddScoped<Backend.Features.Appointments.Interfaces.IAppointmentRepository, Backend.Features.Appointments.Repositories.AppointmentRepository>();
builder.Services.AddScoped<Backend.Features.Appointments.Interfaces.IAppointmentService, Backend.Features.Appointments.Services.AppointmentService>();

builder.Services.AddScoped<Backend.Features.MedicalRecords.Interfaces.IMedicalRecordRepository, Backend.Features.MedicalRecords.Repositories.MedicalRecordRepository>();
builder.Services.AddScoped<Backend.Features.MedicalRecords.Interfaces.IMedicalRecordService, Backend.Features.MedicalRecords.Services.MedicalRecordService>();

// Configure JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key is missing");
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer is missing");
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience is missing");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Map Feature Endpoints
Backend.Features.Roles.Endpoints.RoleEndpoints.MapRoleEndpoints(app);
Backend.Features.Users.Endpoints.UserEndpoints.MapUserEndpoints(app);
Backend.Features.Patients.Endpoints.PatientEndpoints.MapPatientEndpoints(app);
Backend.Features.Appointments.Endpoints.AppointmentEndpoints.MapAppointmentEndpoints(app);
Backend.Features.MedicalRecords.Endpoints.MedicalRecordEndpoints.MapMedicalRecordEndpoints(app);

app.Run();
