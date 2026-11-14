using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.LibraryName = "University Library Management System";
            ViewBag.ContactEmail = "library@university.edu";
            ViewBag.ContactPhone = "+1 (800) 555-0199";
            ViewBag.MaxLoanDays = 14;
            ViewBag.MaxBooksPerMember = 5;
            ViewBag.FinePerDay = "0.50 ₼";
            ViewBag.DatabaseProvider = "Microsoft SQL Server";
            ViewBag.SystemVersion = "v1.2.0";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(string libraryName, string contactEmail, int maxLoanDays, int maxBooksPerMember)
        {
            TempData["SuccessMessage"] = "System configuration updated successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
