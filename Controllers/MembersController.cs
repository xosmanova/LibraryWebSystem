using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var query = _context.Members.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(m => m.FullName.Contains(search) || m.Email.Contains(search) || m.Phone.Contains(search));
            }

            var members = await query.OrderByDescending(m => m.JoinedDate).ToListAsync();

            ViewBag.TotalMembers = await _context.Members.CountAsync();
            ViewBag.ActiveMembers = await _context.Members.CountAsync(m => m.Status == "Active");
            ViewBag.SuspendedMembers = await _context.Members.CountAsync(m => m.Status == "Suspended");
            ViewBag.CurrentSearch = search;

            return View(members);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                member.JoinedDate = System.DateTime.Now;
                member.AvatarUrl = "/images/avatars/avatar1.svg";
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Member '{member.FullName}' was successfully registered!";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null) return NotFound();

            member.Status = member.Status == "Active" ? "Suspended" : "Active";
            await _context.SaveChangesAsync();

            return Json(new { success = true, newStatus = member.Status });
        }
    }
}
