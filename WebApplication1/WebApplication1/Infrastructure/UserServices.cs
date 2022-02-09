using Microsoft.Extensions.Options;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public interface IUserServices
    {
        bool Authenticate(LoginViewModel model);
        User GetUser { get; }
        Role GetRole(int userId);

    }

    public class UserServices : IUserServices
    {
/*        private List<User> _users;
        private List<Role> _roles;
        private List<UserRoles> _userroles;*/
        private User _authenticatedUser = null;

        /*public UserServices(
            IOptions<List<User>> users,
            IOptions<List<Role>> roles,
            IOptions<List<UserRoles>> userRoles)
        {
            _users = users.Value;
            _roles = roles.Value;
            _userroles = userRoles.Value;
        }*/
        AuthenticationContext _authDb;
        public UserServices(AuthenticationContext context) => _authDb = context;


        public bool Authenticate(LoginViewModel model)
        {
            var user = _authDb.Users.FirstOrDefault(c => c.UserName==model.Username && c.Password==model.Password);
            if (user==null)
                return false;
            _authenticatedUser = user;
            return true;
        }

        public Role GetRole(int userId)
        {
            var mappings = _authDb.UserRoles.FirstOrDefault(c=> c.UserId==userId);
            var role = _authDb.Roles.FirstOrDefault(c=>c.RoleId==mappings.RoleId);
            return role;
        }

        public User GetUser { get => _authenticatedUser; }
    }

}
