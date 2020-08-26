using System.Linq;
using System.Security.Claims;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;

namespace HealthSanctuary.Web.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetUserId(this HttpRequest request)
        {
            return request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
