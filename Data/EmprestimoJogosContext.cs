using EmprestimoJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoJogos
{
    public class EmprestimoJogosContext: DbContext
    {
        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public EmprestimoJogosContext(DbContextOptions<EmprestimoJogosContext> options) :
            base(options)
        {
        }
    }
}