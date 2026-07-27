using CRNTechnicalAssessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRNTechnicalAssessment.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string username);
        Task AddRefreshTokenAsync(RefreshToken refreshToken);
    }
}
