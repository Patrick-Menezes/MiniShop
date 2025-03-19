using System.ComponentModel.DataAnnotations;

namespace MiniShop.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(8, ErrorMessage = "A senha deve ter exatamente 8 caracteres.")]
        public string Password { get; set; }
    }
}