using Application.Auth;
using Application.ServiceLocator;
using Blazor_Forum;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Entities;

///
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        options.AccessDeniedPath = "/";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

//
builder.Services.AddScoped<AuthenticationStateProvider, HttpContextAuthenticationStateProvider>();
//

builder.Services.AddScoped<CreateAccountModalState>();
builder.Services.AddScoped<ApplicationUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ThreadServices>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

//

app.MapPost("/auth/login", async (HttpContext context, AuthService authService) =>
{
    var form = await context.Request.ReadFormAsync();
    var username = form["username"].ToString();
    var password = form["password"].ToString();

    var success = await authService.Login(username, password);

    if (!success)
    {
        return Results.Redirect("/?error=1");
    }

    var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, authService.CurrentUser!.ApplicationUserId.ToString()),
        new(ClaimTypes.Name, authService.CurrentUser!.UserName)
    };

    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

    return Results.Redirect("/forum");
});

app.MapPost("/auth/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/");
});
//
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
