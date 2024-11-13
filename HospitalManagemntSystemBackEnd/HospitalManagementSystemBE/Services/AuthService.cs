using HMSFE.Data;
using HMSFE.DTOS;
using HMSFE.helpers;
using HMSFE.Models.DTOS;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HMSFE.Services
{

    public class AuthService : IAuthService
        {
            private readonly JwtSettings _jwtSettings;
            private readonly Context _context;

            public AuthService(IOptions<JwtSettings> jwtSettings, Context context)
            {
                _jwtSettings = jwtSettings.Value;
                _context = context;
            }

            public async Task<AuthResponseDto> PatientLoginAsync(PatientLoginDto loginDto)
            {
                var patient = _context.Users.FirstOrDefault(p => p.Email == loginDto.Email || p.PhoneNumber == loginDto.Email);
                if (patient == null || patient.Password != loginDto.Password)
                {
                    return new AuthResponseDto { Success = false, Message = "Invalid credentials" };
                }

                var token = GenerateJwtToken(patient.PatientId, "Patient");
                patient.RefreshToken = GenerateRefreshToken();
                patient.RefreshTokenExpiryTime = DateTime.Now.AddDays(_jwtSettings.RefreshTokenValidityInDays);
                _context.Users.Update(patient);
                await _context.SaveChangesAsync();

                return new AuthResponseDto { Success = true, Token = token, RefreshToken = patient.RefreshToken };
            }

            public async Task<AuthResponseDto> StaffLoginAsync(StaffLoginDto loginDto)
            {
                var staff = _context.HospitalStaffs.FirstOrDefault(s => s.EmployeeId == loginDto.EmployeeId);
                if (staff == null || staff.Password != loginDto.Password)
                {
                    return new AuthResponseDto { Success = false, Message = "Invalid credentials" };
                }

                var token = GenerateJwtToken(staff.StaffId, staff.Role);
                staff.RefreshToken = GenerateRefreshToken();
                staff.RefreshTokenExpiryTime = DateTime.Now.AddDays(_jwtSettings.RefreshTokenValidityInDays);
                _context.HospitalStaffs.Update(staff);
                await _context.SaveChangesAsync();

                return new AuthResponseDto { Success = true, Token = token, RefreshToken = staff.RefreshToken };
            }

            public async Task<AuthResponseDto> RefreshTokenAsync(TokenAPIDTO tokenRefreshDto)
            {
                var principal = GetPrincipalFromExpiredToken(tokenRefreshDto.Token);
                if (principal == null) return new AuthResponseDto { Success = false, Message = "Invalid Token" };

                var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);
                var patient = await _context.Users.FindAsync(userId);
                if (patient == null || patient.RefreshToken != tokenRefreshDto.RefreshToken || patient.RefreshTokenExpiryTime <= DateTime.Now)
                    return new AuthResponseDto { Success = false, Message = "Invalid refresh token" };

                var newToken = GenerateJwtToken(patient.PatientId, "Patient");
                return new AuthResponseDto { Success = true, Token = newToken, RefreshToken = patient.RefreshToken };
            }

            private string GenerateJwtToken(int userId, string role)
            {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[] {
            //    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            //    new Claim(ClaimTypes.Role, role)
            //}),
            //    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenValidityInMinutes),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            // Ensure the key is not empty
            if (key == null || key.Length == 0)
            {
                throw new ArgumentException("JWT Secret Key is missing or invalid.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Role, role)
        }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenValidityInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

            private string GenerateRefreshToken()
            {
                var random = new byte[32];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(random);
                    return Convert.ToBase64String(random);
                }
            }

            private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                var validationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = false // We check expiry manually
                };

                try
                {
                    var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);
                    if (securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return principal;
                    }
                }
                catch
                {
                    return null;
                }

                return null;
            }
        }
    }

