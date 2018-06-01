using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmprestimoJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoJogos.Controllers
{
    public class LoginController : Controller
    {
        private readonly EmprestimoJogosContext _context;

        public LoginController(EmprestimoJogosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar([Bind("Login, Senha")] Usuario usuario)
        {
            var usuario_valido = await _context.Usuario.SingleOrDefaultAsync(l => l.Login == usuario.Login && l.Senha == usuario.Senha);
            if (usuario_valido == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}