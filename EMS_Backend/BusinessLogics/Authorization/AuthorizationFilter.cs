using BusinessLogics.Helper;
using DataAccessLayer.Intefaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Utilities.Constants;
using Utilities.Exceptions;
using Utilities.Helpers;

namespace BusinessLogics.Authorization
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IHelper _helper;

        public AuthorizationFilter(IHelper helper)
        {
            _helper = helper;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            string? email = httpContext.User.Claims.Single(t => t.Type == ClaimTypes.Email)?.Value;
            var user = AsyncHelper.RunSync(() => _helper.GetUserIdByEmail(email));
            if (user is null)
                throw new CustomException(new Error(Constant.CustomExceptions.Forbidden),HttpStatusCode.Forbidden);

        }
    }
}
