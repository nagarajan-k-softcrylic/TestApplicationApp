using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestApplicationApp.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        // Unauthenticated visitors are redirected to /Secure, which is [Authorize]-protected
        // and will trigger the OIDC Challenge via the authentication middleware. An existing
        // AuthBridge "Cookies" session results in a silent SSO redirect with no login form.
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            return RedirectToPage("/Secure");
        }

        return Page();
    }

    public IActionResult OnGetLogin()
    {
        return Challenge(new AuthenticationProperties { RedirectUri = "/Secure" }, OpenIdConnectDefaults.AuthenticationScheme);
    }

    public IActionResult OnGetLogout()
    {
        return SignOut(
            new AuthenticationProperties { RedirectUri = "/" },
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme);
    }
}
