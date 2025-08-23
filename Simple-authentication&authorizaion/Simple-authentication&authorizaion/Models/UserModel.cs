namespace Simple_authentication_authorizaion.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; } // Admin or User
    }

}
