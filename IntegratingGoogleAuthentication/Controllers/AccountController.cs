using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login(string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
    }

    public IActionResult Logout()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult Profile()
    {

#pragma warning disable CS8602 
        var userName = User.Identity.Name;
#pragma warning restore CS8602
        var userEmail = User.FindFirst("email")?.Value; 


        ViewBag.UserName = userName;
        ViewBag.UserEmail = userEmail;

        return View();
    }
}