using System.ComponentModel.DataAnnotations;

namespace NorthwindWebAPI.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FriendlyName { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            (Id,UserName,FriendlyName) = user; //Tuple - deconstructed to individual fields
            Token = token;
        }
    }

    public class User
    {
        public void Deconstruct(out int Id, out string UserName,out string FriendlyName)
        {
            Id= this.Id; UserName=this.UserName; FriendlyName=this.FriendlyName;
        }

        [Key] public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FriendlyName { get; set; }
    }

    public class Role
    {
        [Key] public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRoles
    {
        [Key] public int UserId { get; set; }
        [Key] public int RoleId { get; set; }
    }
}
