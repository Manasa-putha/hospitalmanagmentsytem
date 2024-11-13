namespace HMSFE.helpers
{
  
        public class JwtSettings
        {
            public string SecretKey { get; set; } = string.Empty;
            public int TokenValidityInMinutes { get; set; }
            public int RefreshTokenValidityInDays { get; set; }
        }
    }



