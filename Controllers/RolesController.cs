using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            var roles = new List<dynamic>
            {
                new { Id = 1, Name = "Administrator", Description = "Full administrative access to catalog, circulation, users and system configuration", UsersCount = 2, Permissions = new[] { "Manage Books Catalog", "Manage Members", "View Analytics", "System Settings", "Database Operations" } },
                new { Id = 2, Name = "Librarian", Description = "Daily circulation desk operations, issuing, returning, and tracking overdue items", UsersCount = 5, Permissions = new[] { "Manage Books Catalog", "Issue & Return Books", "View Members", "Track Overdues" } },
                new { Id = 3, Name = "Faculty", Description = "Extended borrowing limits, research title requests, and priority reservations", UsersCount = 12, Permissions = new[] { "Request Books", "Reserve Titles", "Browse Catalog" } },
                new { Id = 4, Name = "Student", Description = "Standard student member borrowing privileges and catalog search", UsersCount = 25, Permissions = new[] { "Catalog Search", "Borrow Books" } }
            };

            return View(roles);
        }

        [HttpPost]
        public IActionResult SavePermissions()
        {
            TempData["SuccessMessage"] = "Roles and permissions updated successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
