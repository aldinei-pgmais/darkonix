using DarkOnix.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DarkOnix.Mvc.Controllers;

public sealed class IdentidadeController : Controller
{
    [HttpGet("nova-conta")]
    public async Task<IActionResult> Registro()
    {
        return View();
    }

    [HttpPost("nova-conta")]
    public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
    {
        if (!ModelState.IsValid) return View(usuarioRegistro);

        // API-Registro
        if (false) return View(usuarioRegistro);

        return RedirectToAction("Login");
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
    {
        if (!ModelState.IsValid) return View(usuarioLogin);

        // Realizar login
        if (false) return View(usuarioLogin);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("sair")]
    public async Task<IActionResult> Logout()
    {
        // Realizar logoff
        return RedirectToAction("Index", "Home");
    }
}
