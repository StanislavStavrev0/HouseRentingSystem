
namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions // Identity
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
