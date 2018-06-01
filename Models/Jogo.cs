using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoJogos.Models
{
    public class Jogo
    {
        [Key]
        public int JogoID { get; set; }
        [Required]
        public string Nome { get; set; }
        public int? AmigoID { get; set; }
        [NotMapped]
        public string NomeAmigo { get; set; }
    }
}