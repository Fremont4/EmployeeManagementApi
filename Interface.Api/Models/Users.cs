namespace Interface.Api.Models
{
    public class Users
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }

        public string Department { get; set; }
        public string password { get; set; }
    }
}
