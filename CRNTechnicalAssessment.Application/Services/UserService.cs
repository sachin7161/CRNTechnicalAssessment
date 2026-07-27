using CRNTechnicalAssessment.Application.DTOs;
using CRNTechnicalAssessment.Application.Interfaces;
using CRNTechnicalAssessment.Domain.Entities;

namespace CRNTechnicalAssessment.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
           

            var user = await _userRepository.GetByUserNameAsync(request.UserName);

            if (user == null)
            {
                Console.WriteLine(" User NOT FOUND");
                return null;
            }


            Console.WriteLine(" Login Success");

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _userRepository.AddRefreshTokenAsync(new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id,
                IsRevoked = false
            });

            await _unitOfWork.SaveChangesAsync();

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(30)
            };
        }
    }
}