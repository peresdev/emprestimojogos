using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmprestimoJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoJogos.Controllers
{
    public class AmigosController : Controller
    {

        private readonly EmprestimoJogosContext _context;

        public AmigosController(EmprestimoJogosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Amigo.ToListAsync());
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind("AmigoID, Nome")] Amigo amigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amigo);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo.SingleOrDefaultAsync(m => m.AmigoID == id);
            if (amigo == null)
            {
                return NotFound();
            }
            return View(amigo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int AmigoID, [Bind("AmigoID, Nome")] Amigo amigo)
        {
            if (AmigoID != amigo.AmigoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExisteAmigo(amigo.AmigoID))
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
            return View(amigo);
        }

        public async Task<IActionResult> Remover(int id)
        {
            if (ExisteAmigo(id))
            {
                var amigo = await _context.Amigo.SingleOrDefaultAsync(m => m.AmigoID == id);
                _context.Amigo.Remove(amigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else {
                return NotFound();
            }
        }

        private bool ExisteAmigo(int id)
        {
            return _context.Amigo.Any(e => e.AmigoID == id);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
