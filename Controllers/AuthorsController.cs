using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            return View(authors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.AvatarUrl = "/images/avatars/avatar1.svg";
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Author '{author.Name}' was successfully added!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
