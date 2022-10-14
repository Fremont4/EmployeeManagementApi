using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Interface.Api.Models
{
    public record LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email { get; set; }
        public string Password { get; set; }
        //public string RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }
        //public string Department { get; set; }
        //public string FullName { get; set; }
    }
}
