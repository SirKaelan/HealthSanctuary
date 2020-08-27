using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace HealthSanctuary.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this HttpContext context)
        {
            return context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
