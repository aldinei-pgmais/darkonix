using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DarkOnix.Identidade.Api.Models.Usuarios;

public sealed class UsuarioRegistro
{
    [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo '{0}' está em um formato inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo '{0}' precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    public string Senha { get; set; } = string.Empty;

    [DisplayName("Confirme sua senha")]
    [Compare(nameof(Senha), ErrorMessage = "As senhas não conferem")]
    public string SenhaConfirmacao { get; set; } = string.Empty;
}