using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoJogos.Models
{
    public class Amigo
    {
        public int AmigoID { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<Jogo> Jogos { get; set; }
    }
}