using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace NorthwindWebAPI.Models
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context,IUserServices userServices)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(token is not null)
            {
                //Do something;
                //parsr the token and validate it
                try
                {
                    JwtSecurityTokenHandler tokenHandler = new();
                    var key = System.Text.Encoding.UTF8.GetBytes("manipalBajajDotNetCoreTrainingSchedule");
                    tokenHandler.ValidateToken(token, new TokenValidationParameters(){
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero,
                    }, out SecurityToken validatedToken);
                    var jwtToken = validatedToken as JwtSecurityToken;
                    var userName = jwtToken.Claims.First(c=> c.Type == "Username").Value;
                    var role = jwtToken.Claims.First(r => r.Type == "Role").Value;
                    context.Items["User"] = userName;
                    context.Items["Role"] = role;
                }
                catch (Exception ex) { throw; }
            }
                await _next(context);
        }
    }
}
