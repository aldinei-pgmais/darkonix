using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DarkOnix.Identity.Api.Models.Users;

public sealed class UserRegister
{
    [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo '{0}' está em um formato inválido")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Senha")]
    [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo '{0}' precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    [DisplayName("Confirme sua senha")]
    [Compare(nameof(Password), ErrorMessage = "As senhas não conferem")]
    public string PasswordConfirmation { get; set; } = string.Empty;
}