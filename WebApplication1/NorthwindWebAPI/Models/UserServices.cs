using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace NorthwindWebAPI.Models
{
    public interface IUserServices
    {
        AuthenticationResponse Authenticate(LoginModel model);
        User GetUser { get; }
        Role GetRole(int userId);

    }

    public class UserServices : IUserServices
    {
        private User _authenticatedUser = null;

        BFLUsersContext _authDb;
        public UserServices(BFLUsersContext context) => _authDb = context;


        public AuthenticationResponse Authenticate(LoginModel model)
        {
            var user = _authDb.Users.FirstOrDefault(c => c.UserName == model.Username && c.Password == model.Password);
            if(user == null) return null;
            _authenticatedUser = user;
            var role = GetRole(user.Id);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes("manipalBajajDotNetCoreTrainingSchedule");
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("Username", _authenticatedUser.UserName),
                    new System.Security.Claims.Claim("Role", role.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var preToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(preToken);
            var authResponse = new AuthenticationResponse(_authenticatedUser,token);
            return authResponse;
        }

        public Role GetRole(int userId)
        {
            var mappings = _authDb.UserRoles.FirstOrDefault(c => c.UserId == userId);
            var role = _authDb.Roles.FirstOrDefault(c => c.RoleId == mappings.RoleId);
            return role;
        }

        public User GetUser { get => _authenticatedUser; }
    }
}
