namespace HardwareStore.App.Extension
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System.Security.Claims;

    public static class ClaimsPrincipalExtension
    {
        public static string? Id(this ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            return userId;
        }
    }
}
