using CRNTechnicalAssessment.Application.Interfaces;
using CRNTechnicalAssessment.Domain.Entities;
using CRNTechnicalAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRNTechnicalAssessment.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUserNameAsync(string username)
        {

            var totalUsers = await _context.Users.CountAsync();

            var user = await _context.Users.FirstOrDefaultAsync(x =>x.UserName.ToLower() == username.ToLower());

            if (user == null)
            {
                Console.WriteLine("User NOT FOUND");
            }
            else
            {
                Console.WriteLine($"FOUND USER : {user.UserName}");
            }

            return user;
        }

        public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }
    }

}