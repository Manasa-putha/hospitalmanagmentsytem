using System.ComponentModel.DataAnnotations;

namespace HMSFE.Models
{
   
    public class User
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }

    }




