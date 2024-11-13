
using global::HMSFE.Models.DTOS;
using HMSFE.DTOS;



namespace HMSFE.Services
{

    public interface IAuthService
        {
            Task<AuthResponseDto> PatientLoginAsync(PatientLoginDto loginDto);
            Task<AuthResponseDto> StaffLoginAsync(StaffLoginDto loginDto);
            Task<AuthResponseDto> RefreshTokenAsync(TokenAPIDTO tokenRefreshDto);
        }

  }


