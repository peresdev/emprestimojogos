using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmprestimoJogos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EmprestimoJogos.Controllers
{
    public class JogosController : Controller
    {

        private readonly EmprestimoJogosContext _context;

        public JogosController(EmprestimoJogosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jogos = from jogo in _context.Jogo
                        join amigo in _context.Amigo on jogo.AmigoID equals amigo.AmigoID into ja
                        from subq in ja.DefaultIfEmpty()
                        select new Jogo
                        {
                            JogoID = jogo.JogoID,
                            Nome = jogo.Nome,
                            NomeAmigo = subq.Nome
                        };

            return View(jogos);

        }

        private void ToList()
        {
            throw new NotImplementedException();
        }

        public IActionResult Adicionar()
        {
            PopularAmigosDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind("JogoID, Nome, AmigoID")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogo.SingleOrDefaultAsync(m => m.JogoID == id);
            if (jogo == null)
            {
                return NotFound();
            }
            PopularAmigosDropDownList(jogo);
            return View(jogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int JogoID, [Bind("JogoID, Nome, AmigoID")] Jogo jogo)
        {
            if (JogoID != jogo.JogoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExisteJogo(jogo.JogoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        public async Task<IActionResult> Remover(int id)
        {
            if (ExisteJogo(id))
            {
                var jogo = await _context.Jogo.SingleOrDefaultAsync(m => m.JogoID == id);
                _context.Jogo.Remove(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        private bool ExisteJogo(int id)
        {
            return _context.Jogo.Any(e => e.JogoID == id);
        }

        private void PopularAmigosDropDownList(object selectedAmigo = null)
        {
            var amigosQuery = from a in _context.Amigo
                                   orderby a.Nome
                                   select a;
            ViewBag.AmigoID = new SelectList(amigosQuery.AsNoTracking(), "AmigoID", "Nome", selectedAmigo);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
