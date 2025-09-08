using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Auth_demo.Models;

namespace Auth_demo.Services;

public class AuthService
{
    public async Task<string> LoginAsync(HttpContext http, Login dto)
    {
        // Basic demo validation
        if (dto.Username != "admin" || dto.Password != "password")
            return "Invalid credentials";

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, dto.Username),
            new Claim("role", "Admin")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        var authProps = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

        return "login successfully";
    }
}
