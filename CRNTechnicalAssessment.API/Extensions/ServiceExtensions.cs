using CRNTechnicalAssessment.Application.Interfaces;
using CRNTechnicalAssessment.Application.Services;
using CRNTechnicalAssessment.Infrastructure.Data;
using CRNTechnicalAssessment.Infrastructure.Identity;
using CRNTechnicalAssessment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRNTechnicalAssessment.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(
                configuration.GetSection("Jwt"));

            // JWT
            services.AddScoped<ITokenService, TokenService>();

            // User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // Product
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();   

            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}