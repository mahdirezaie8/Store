using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Domain.Core.Entities;
using System.Security.Claims;

namespace Store.EndPoint.MVC.Extention
{
    public static class UserExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                return userId;
            return null;
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole("Admin")||user.Claims.Any(c=>c.Type==ClaimTypes.Role&&c.Value=="Admin");
        }
        public static bool UserIsLoggedIn(this ClaimsPrincipal user)
        {
            return user.Identity != null && user.Identity.IsAuthenticated;
        }
        public static string? GetUserName(this ClaimsPrincipal user)
        {
            return user.Identity?.Name ?? user.FindFirst(ClaimTypes.Name)?.Value;
        }
        public static string? GetUserRole(this ClaimsPrincipal user)
        {
            return user.Claims
                       .FirstOrDefault(c => c.Type == ClaimTypes.Role)
                       ?.Value;
        }
    }
}
