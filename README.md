# Library Management System

A web-based library and book circulation management system built with **ASP.NET Core MVC** and **Entity Framework Core**, backed by **Microsoft SQL Server**.



## Tech Stack
- **Backend:** C# / ASP.NET Core MVC (.NET 10.0)
- **Database:** Microsoft SQL Server / Entity Framework Core
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap 5

---

## Core Features
1. **Dashboard & Analytics:** Live book metrics and dynamic circulation rate chart (Issued, Reserved, Overdue, Available).
2. **Books Catalog (CRUD):** Create, view, edit, delete books, search by title/author/publisher, filter by category/status, and instant status toggle.
3. **Members:** Manage student, faculty, and standard library members, track borrowed books, and add new members.
4. **Publishers & Authors:** Directory of publishing houses and authors with biographical information and cataloged works.
5. **Roles & Permissions:** Role matrix configuring access rights for Administrators, Librarians, Faculty, and Students.
6. **System Settings:** Configure circulation limits, loan periods, and overdue daily fines.

---

## Project Structure

```text
LibraryManagementSystem/
├── Controllers/       # Request handlers & application logic
│   ├── HomeController.cs
│   ├── BooksController.cs
│   ├── MembersController.cs
│   ├── PublishersController.cs
│   ├── AuthorsController.cs
│   ├── RolesController.cs
│   ├── SettingsController.cs
│   └── AccountController.cs
├── Models/            # Database entities & view models
│   ├── Book.cs
│   ├── Member.cs
│   ├── Publisher.cs
│   ├── Author.cs
│   ├── DashboardViewModel.cs
│   └── LoginViewModel.cs
├── Data/              # EF Core database context & seed data
│   └── AppDbContext.cs
├── Views/             # UI Razor views (.cshtml)
│   ├── Home/          # Dashboard view
│   ├── Books/         # Book CRUD views
│   ├── Members/
│   ├── Publishers/
│   ├── Authors/
│   ├── Roles/
│   ├── Settings/
│   ├── Account/       # Login view
│   └── Shared/        # Layout, navbar, sidebar
├── wwwroot/           # Static assets (CSS, JS, images, SVG covers)
├── appsettings.json   # Configuration & database connection
└── Program.cs         # App entry point & service registration
```

---

