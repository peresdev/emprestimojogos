using System.ComponentModel.DataAnnotations;

namespace EmprestimoJogos.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
