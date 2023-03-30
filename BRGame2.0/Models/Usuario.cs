using System.ComponentModel.DataAnnotations;

namespace BRGame2._0.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu Email!")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua Senha!")]
        [MinLength(1)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe sua idade!")]
        public string Idade { get; set; }
    }
}
