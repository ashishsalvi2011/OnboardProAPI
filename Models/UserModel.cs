namespace OnboardPro.Models
{
    public class UserModel
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; } // Store hashed password
            public string Role { get; set; }

    }

}
