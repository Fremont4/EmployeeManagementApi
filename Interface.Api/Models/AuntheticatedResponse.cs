namespace Interface.Api.Models
{
    public class AuntheticatedResponse
    {
        public string Token { get; set; }
        public bool responseCode { get; set; }
        public string responseDescription { get; set; }
    }
}
