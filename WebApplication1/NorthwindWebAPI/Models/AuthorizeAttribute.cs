using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthwindWebAPI.Models
{
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var user = context.HttpContext.Items["User"].ToString();
                //if (user is null)
                if(string.IsNullOrEmpty(user))
                    {
                    context.Result = new JsonResult(new { message = "Unauthorized" })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized 
                    };
                }
            }
        }
}
