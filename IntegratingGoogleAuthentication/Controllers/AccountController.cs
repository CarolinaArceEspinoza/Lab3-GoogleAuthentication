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

    // Nueva acción para la página de perfil
    [Authorize] // Asegura que el usuario esté autenticado para acceder a esta página
    public IActionResult Profile()
    {
        // Obtener la información del usuario
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        var userName = User.Identity.Name;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
        var userEmail = User.FindFirst("email")?.Value; // Suponiendo que el correo electrónico del usuario está almacenado como una reclamación llamada "email"


        // Pasa la información del usuario a la vista
        ViewBag.UserName = userName;
        ViewBag.UserEmail = userEmail;

        return View();
    }
}