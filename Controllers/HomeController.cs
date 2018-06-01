using Microsoft.AspNetCore.Mvc;
using EmprestimoJogos.Models;
using System.Linq;

namespace EmprestimoJogos.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmprestimoJogosContext _context;

        public HomeController(EmprestimoJogosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var amigos_cadastrados = _context.Amigo.Count();
            var jogos_cadastrados = _context.Jogo.Count();
            var jogos_emprestados = (from jogo in _context.Jogo
                        join amigo in _context.Amigo on jogo.AmigoID equals amigo.AmigoID
                        select new Jogo
                        {
                            JogoID = jogo.JogoID,
                            Nome = jogo.Nome,
                            NomeAmigo = amigo.Nome
                        }).Count();

            ViewBag.AmigosCadastrados = amigos_cadastrados;
            ViewBag.JogosCadastrados = jogos_cadastrados;
            ViewBag.JogosEmprestados = jogos_emprestados;

            return View();
        }
    }
}
