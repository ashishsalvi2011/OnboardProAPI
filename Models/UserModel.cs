namespace OnboardPro.Models
{
    public class UserModel
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; } // Store hashed password
            public string Role { get; set; }

    }

    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
    
    public class UserDto
    {
        public int UserId { get; set; } = 0;
        public string PsNumber { get; set; }
        public string Name { get; set; }
        public int Project { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserType { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class UserResponseDto : UserDto
    {
        public string ProjectName { get; set; }
        public string UserTypeName { get; set; }
    }

}
