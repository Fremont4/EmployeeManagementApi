namespace Interface.Api.Models
{
    public record LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
