namespace Interface.Api.Models
{
    public class AuntheticatedResponse
    {
        public string Token { get; set; }
        public bool ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string RefreshToken { get; set; }
    }
}
