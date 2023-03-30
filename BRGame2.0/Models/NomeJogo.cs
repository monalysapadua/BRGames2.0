using System.ComponentModel.DataAnnotations;

namespace BRGame2._0.Models
{
    public class NomeJogo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o nome do Jogo!")]
        public string Jogo { get; set; }
    }
}
