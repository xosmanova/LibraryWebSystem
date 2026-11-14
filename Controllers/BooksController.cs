using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // Books catalog index with search and filters
        public async Task<IActionResult> Index(string? searchString, string? category, string? status, string? sortBy)
        {
            var query = _context.Books.AsQueryable();

            // Search by title, author or publisher
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var search = searchString.Trim();
                query = query.Where(b => b.Title.Contains(search) || 
                                         b.Author.Contains(search) || 
                                         (b.Publisher != null && b.Publisher.Contains(search)));
            }

            // Category filter
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(b => b.Category == category);
            }

            // Status filter
            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(b => b.Status == status);
            }

            // Sorting order
            query = sortBy switch
            {
                "title_asc" => query.OrderBy(b => b.Title),
                "title_desc" => query.OrderByDescending(b => b.Title),
                "author" => query.OrderBy(b => b.Author),
                "copies" => query.OrderByDescending(b => b.CopiesAvailable),
                "price" => query.OrderByDescending(b => b.Price),
                _ => query.OrderByDescending(b => b.CreatedAt)
            };

            var books = await query.ToListAsync();

            // Distinct categories for filter dropdown
            ViewBag.Categories = await _context.Books
                .Select(b => b.Category)
                .Distinct()
                .ToListAsync();

            ViewBag.CurrentSearch = searchString;
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentStatus = status;
            ViewBag.CurrentSort = sortBy;
            ViewBag.TotalCount = await _context.Books.CountAsync();
            ViewBag.ActiveCount = await _context.Books.CountAsync(b => b.IsActive);

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            PopulateCategories();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                PopulateCategories();
                return View(book);
            }

            book.CreatedAt = DateTime.Now;

            // Fallback cover image if none provided
            if (string.IsNullOrWhiteSpace(book.CoverImageUrl))
            {
                book.CoverImageUrl = "/images/covers/book1001.svg";
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Book '{book.Title}' was successfully added!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            PopulateCategories();
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                PopulateCategories();
                return View(book);
            }

            var existing = await _context.Books.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Title = book.Title;
            existing.AlternateTitle = book.AlternateTitle;
            existing.Author = book.Author;
            existing.Category = book.Category;
            existing.Publisher = book.Publisher;
            existing.Language = book.Language;
            existing.CopiesAvailable = book.CopiesAvailable;
            existing.Price = book.Price;
            existing.Status = book.Status;
            existing.IsActive = book.IsActive;
            existing.Description = book.Description;
            if (!string.IsNullOrWhiteSpace(book.CoverImageUrl))
            {
                existing.CoverImageUrl = book.CoverImageUrl;
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Book '{book.Title}' was successfully updated!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Book '{book.Title}' was successfully removed!";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Books/ToggleStatus/5 (Quick AJAX status toggle switch)
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.IsActive = !book.IsActive;
            await _context.SaveChangesAsync();

            return Ok(new { success = true, isActive = book.IsActive });
        }

        private void PopulateCategories()
        {
            var categories = new List<string>
            {
                "Self development",
                "Novels",
                "Comedy",
                "Drama & Romance",
                "Health, Fitness & Dieting",
                "Computer Science",
                "History & Politics",
                "Science & Nature"
            };
            ViewBag.CategoryList = new SelectList(categories);
        }
    }
}
