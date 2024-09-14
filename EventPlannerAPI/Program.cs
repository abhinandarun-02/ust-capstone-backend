using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EventPlannerAPI.Mapping;
using EventPlannerAPI.Data;
using Microsoft.EntityFrameworkCore;
using EventPlannerAPI.Repositories.Services;
using EventPlannerAPI.Repositories;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<IWeddingRepository, WeddingRepository>();
        builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
        builder.Services.AddScoped<IPhotographyRepository, PhotographyRepository>();
        builder.Services.AddScoped<IVenueRepository, VenueRepository>();
        builder.Services.AddScoped<ICateringRepository, CateringRepository>();
        builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

        builder.Services.AddDbContext<EventPlannerDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddHttpContextAccessor();


        ConfigurationManager configuration = builder.Configuration;

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            };
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}