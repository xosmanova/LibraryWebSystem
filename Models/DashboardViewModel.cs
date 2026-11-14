using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class DashboardViewModel
    {
        public int TotalBooks { get; set; }
        public int TotalMembers { get; set; } = 44;
        public int IssuedBooks { get; set; }
        public int ReservedBooks { get; set; }
        public int OverdueBooks { get; set; }
        public int AvailableBooks { get; set; }
        public int ActiveBooksCount { get; set; }
        public int TotalCategories { get; set; }
        public List<Book> RecentCirculation { get; set; } = new();
        public Dictionary<string, int> CategoryCounts { get; set; } = new();
    }
}
