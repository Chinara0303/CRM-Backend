using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Services.Mappings;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services.Services;
using Services.Services.İnterfaces;
using Repository.Repositories.İnterfaces;
using Repository.Repositories;
using Services.Helpers.AccountSetting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<EmailSetting>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.RequireUniqueEmail = false;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));

builder.Services.AddScoped<JWTSettings>();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
    });


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ITimeRepository, TimeRepository>();
builder.Services.AddScoped<ISeansRepository, SeansRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<ITeacherSocialRepository, TeacherSocialRepository>();
builder.Services.AddScoped<IStaffSocialRepository, StaffSocialRepository>();
builder.Services.AddScoped<ITeacherSocialRepository, TeacherSocialRepository>();
builder.Services.AddScoped<ISiteSocialRepository, SiteSocialRepository>();
builder.Services.AddScoped<IStaffPositionRepository, StaffPositionRepository>();
builder.Services.AddScoped<ITeacherGroupRepository, TeacherGroupRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ISubscribeRepository, SubscribeRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<ISeansService, SeansService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ITeacherSocialService, TeacherSocialService>();
builder.Services.AddScoped<IStaffSocialService, StaffSocialService>();
builder.Services.AddScoped<ITeacherSocialService, TeacherSocialService>();
builder.Services.AddScoped<ISiteSocialService, SiteSociaService>();
builder.Services.AddScoped<ITeacherGroupService, TeacherGroupService>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<IContactService, ContactService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
