using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth_demo.Models;
using Auth_demo.Services;


var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.Cookie.Name = "authdemo.cookie";
    options.Cookie.SameSite = SameSiteMode.None; // allow cross-origin or fetch
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // requires HTTPS
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", async (HttpContext http, Login dto, AuthService authService) =>
{
    var result = await authService.LoginAsync(http, dto);
    return Results.Text(result);
});

app.MapPost("/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Text("logout successfully");
});
app.MapGet("/", () => "Welcome! Try POST /login and GET /me");

app.MapGet("/me", (HttpContext http) =>
{
    var name = http.User.Identity?.Name ?? "Guest";
    return Results.Text($"You are {name}, Authenticated = {http.User.Identity?.IsAuthenticated}");
}).RequireAuthorization();

app.Run();
