using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion.Models;

namespace ProyectoProgramacion.Controllers
{
    public class ReservacionesController : Controller
    {
        private readonly RestauranteSistemaContext _context;

        public ReservacionesController(RestauranteSistemaContext context)
        {
            _context = context;
        }

        // GET: Reservaciones
        public async Task<IActionResult> Index()
        {
            var restauranteSistemaContext = _context.Reservacions.Include(r => r.IdRestauranteNavigation).Include(r => r.IdUsuarioNavigation);
            return View(await restauranteSistemaContext.ToListAsync());
        }

        // GET: Reservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions
                .Include(r => r.IdRestauranteNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // GET: Reservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdRestaurante"] = new SelectList(_context.Restaurantes, "IdRestaurante", "IdRestaurante");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Reservaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,IdUsuario,IdRestaurante,FechaReservacion")] Reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRestaurante"] = new SelectList(_context.Restaurantes, "IdRestaurante", "IdRestaurante", reservacion.IdRestaurante);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reservacion.IdUsuario);
            return View(reservacion);
        }

        // GET: Reservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }
            ViewData["IdRestaurante"] = new SelectList(_context.Restaurantes, "IdRestaurante", "IdRestaurante", reservacion.IdRestaurante);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reservacion.IdUsuario);
            return View(reservacion);
        }

        // POST: Reservaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion,IdUsuario,IdRestaurante,FechaReservacion")] Reservacion reservacion)
        {
            if (id != reservacion.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionExists(reservacion.IdReservacion))
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
            ViewData["IdRestaurante"] = new SelectList(_context.Restaurantes, "IdRestaurante", "IdRestaurante", reservacion.IdRestaurante);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reservacion.IdUsuario);
            return View(reservacion);
        }

        // GET: Reservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions
                .Include(r => r.IdRestauranteNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservacions == null)
            {
                return Problem("Entity set 'RestauranteSistemaContext.Reservacions'  is null.");
            }
            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion != null)
            {
                _context.Reservacions.Remove(reservacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionExists(int id)
        {
          return (_context.Reservacions?.Any(e => e.IdReservacion == id)).GetValueOrDefault();
        }
    }
}
