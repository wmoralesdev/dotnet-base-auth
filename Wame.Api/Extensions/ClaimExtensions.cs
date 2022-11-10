using System.Security.Claims;

namespace Wame.Api.Extensions;

public static class ClaimExtensions
{
    public static string GetEmailFromClaims(this IEnumerable<Claim> claims) =>
        claims.FirstOrDefault(c => c.Type == "Email")!.Value;
}