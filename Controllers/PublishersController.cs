using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class PublishersController : Controller
    {
        private readonly AppDbContext _context;

        public PublishersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return View(publishers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Add(publisher);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Publisher '{publisher.Name}' was successfully added!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
