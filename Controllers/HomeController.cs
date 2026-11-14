using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            var membersCount = await _context.Members.CountAsync();

            var viewModel = new DashboardViewModel
            {
                TotalBooks = books.Count,
                TotalMembers = membersCount > 0 ? membersCount : 44,
                IssuedBooks = books.Count(b => b.Status == "Issued"),
                ReservedBooks = books.Count(b => b.Status == "Reserved"),
                OverdueBooks = books.Count(b => b.Status == "Overdue"),
                AvailableBooks = books.Count(b => b.Status == "Available"),
                ActiveBooksCount = books.Count(b => b.IsActive),
                TotalCategories = books.Select(b => b.Category).Distinct().Count(),
                RecentCirculation = books.OrderByDescending(b => b.CreatedAt).Take(8).ToList()
            };

            // Category counts for stats/charts
            viewModel.CategoryCounts = books
                .GroupBy(b => b.Category)
                .ToDictionary(g => g.Key, g => g.Count());

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
