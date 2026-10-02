using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestApplicationApp.Pages;

[Authorize]
public class SecureModel : PageModel
{
    public bool HasAppAccess { get; private set; }

    public void OnGet()
    {
        HasAppAccess = User.Claims.Any(c => c.Type == "app_access" && c.Value == "TEST_APP");
    }
}
