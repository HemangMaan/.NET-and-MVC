using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
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
    public enum RoleType {  Admin=1,USer=2,Operator=3};
}
