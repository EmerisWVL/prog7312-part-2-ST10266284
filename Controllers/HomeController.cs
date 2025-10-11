using Microsoft.AspNetCore.Mvc;
using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MunicipalServicesApp.Controllers
{
    public class HomeController : Controller
    {
        // In-memory storage for reports (Part 1)
        private static readonly List<Report> _reports = new List<Report>();

        // In-memory events for Part 2 (sample events)
        private static readonly List<Event> _events = new List<Event>
        {
            new Event { Id = 1, Name = "Community Clean-Up", Category = "Environment", Description = "Join us to keep our neighborhood clean!", Date = DateTime.Today.AddDays(3) },
            new Event { Id = 2, Name = "Health Awareness Day", Category = "Health", Description = "Free health screenings and awareness sessions.", Date = DateTime.Today.AddDays(5) },
            new Event { Id = 3, Name = "Youth Sports Tournament", Category = "Sports", Description = "Annual youth soccer and basketball games.", Date = DateTime.Today.AddDays(10) },
            new Event { Id = 4, Name = "Tree Planting Drive", Category = "Environment", Description = "Help us plant 100 new trees this weekend.", Date = DateTime.Today.AddDays(7) },
            new Event { Id = 5, Name = "Tech & Innovation Fair", Category = "Education", Description = "Discover new local startups and innovations.", Date = DateTime.Today.AddDays(15) },
            new Event { Id = 6, Name = "Local Farmers Market", Category = "Food", Description = "Fresh produce and homemade treats every Sunday.", Date = DateTime.Today.AddDays(1) },
            new Event { Id = 7, Name = "Book Donation Drive", Category = "Education", Description = "Donate old books and promote literacy in the community.", Date = DateTime.Today.AddDays(8) },
            new Event { Id = 8, Name = "Neighborhood Safety Talk", Category = "Public Safety", Description = "Learn about safety measures with local authorities.", Date = DateTime.Today.AddDays(4) },
            new Event { Id = 9, Name = "Charity Fun Run", Category = "Health", Description = "Join our 5K charity run for hospital donations.", Date = DateTime.Today.AddDays(12) },
            new Event { Id = 10, Name = "Cultural Food Festival", Category = "Culture", Description = "Celebrate diversity with traditional food stalls.", Date = DateTime.Today.AddDays(9) },
            new Event { Id = 11, Name = "Coding Bootcamp", Category = "Education", Description = "Learn coding basics in one day.", Date = DateTime.Today.AddDays(14) },
            new Event { Id = 12, Name = "Art in the Park", Category = "Culture", Description = "Enjoy local artists displaying and selling artwork.", Date = DateTime.Today.AddDays(11) },
            new Event { Id = 13, Name = "Pet Adoption Day", Category = "Community", Description = "Find your furry friend from our local shelters.", Date = DateTime.Today.AddDays(6) },
            new Event { Id = 14, Name = "Water Conservation Workshop", Category = "Environment", Description = "Learn how to save water efficiently at home.", Date = DateTime.Today.AddDays(2) },
            new Event { Id = 15, Name = "Blood Donation Drive", Category = "Health", Description = "Give the gift of life. Donate blood today.", Date = DateTime.Today.AddDays(13) }
        };

        // Optional recommendation tracking
        private static readonly Dictionary<string, int> _searchCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // -------------------------
        // Part 1: Reports (existing)
        // -------------------------
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportIssue()
        {
            return View(new Report());
        }

        [HttpPost]
        public async Task<IActionResult> ReportIssue(Report model, List<IFormFile> mediaAttachments)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Save uploaded files to wwwroot/uploads
            var attachmentPaths = new List<string>();
            if (mediaAttachments != null)
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(uploadDir);

                foreach (var file in mediaAttachments)
                {
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(uploadDir, fileName);
                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fs);
                        }
                        attachmentPaths.Add($"/uploads/{fileName}");
                    }
                }
            }

            model.SubmissionTimestamp = DateTime.Now;
            model.MediaAttachments = attachmentPaths;
            _reports.Add(model);

            TempData["SuccessMessage"] = "Thank you for your report! Your input helps improve our community.";

            // IMPORTANT: redirect using route parameter name 'id' (matches default route)
            return RedirectToAction("ViewReport", new { id = _reports.Count - 1 });
        }

        // Updated to accept 'id' route parameter
        public IActionResult ViewReport(int id)
        {
            if (id < 0 || id >= _reports.Count)
            {
                TempData["ErrorMessage"] = "Report not found.";
                return RedirectToAction("Index");
            }

            var model = _reports[id];
            return View(model);
        }

        // -------------------------
        // Part 2: Local Events
        // -------------------------
        public IActionResult LocalEvents(string? searchQuery, string? searchCategory, string? searchDate, string? sortBy)
        {
            var result = _events.AsEnumerable();

            // Filter by name
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                result = result.Where(e => e.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
                if (_searchCounts.ContainsKey(searchQuery)) _searchCounts[searchQuery]++;
                else _searchCounts[searchQuery] = 1;
            }

            // Filter by category
            if (!string.IsNullOrWhiteSpace(searchCategory))
            {
                result = result.Where(e => e.Category.Equals(searchCategory, StringComparison.OrdinalIgnoreCase));
                if (_searchCounts.ContainsKey(searchCategory)) _searchCounts[searchCategory]++;
                else _searchCounts[searchCategory] = 1;
            }

            // Filter by date
            if (!string.IsNullOrWhiteSpace(searchDate) && DateTime.TryParse(searchDate, out DateTime parsed))
            {
                result = result.Where(e => e.Date.Date == parsed.Date);
                var key = parsed.ToString("yyyy-MM-dd");
                if (_searchCounts.ContainsKey(key)) _searchCounts[key]++;
                else _searchCounts[key] = 1;
            }

            // Sorting
            result = sortBy switch
            {
                "NameAsc" => result.OrderBy(e => e.Name),
                "NameDesc" => result.OrderByDescending(e => e.Name),
                "DateAsc" => result.OrderBy(e => e.Date),
                "DateDesc" => result.OrderByDescending(e => e.Date),
                _ => result.OrderBy(e => e.Date)
            };

            ViewBag.Categories = _events.Select(e => e.Category).Distinct().OrderBy(c => c).ToList();
            ViewBag.SearchCategory = searchCategory;
            ViewBag.SortBy = sortBy;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SearchDate = searchDate;

            // Recommendations simple: top categories searched
            var recommended = new List<Event>();
            if (_searchCounts.Any())
            {
                var topCats = _searchCounts.OrderByDescending(kvp => kvp.Value)
                                          .Select(kvp => kvp.Key)
                                          .Where(k => _events.Any(ev => ev.Category.Equals(k, StringComparison.OrdinalIgnoreCase)))
                                          .Take(3)
                                          .ToList();

                foreach (var c in topCats)
                {
                    recommended.AddRange(_events.Where(ev => ev.Category.Equals(c, StringComparison.OrdinalIgnoreCase)));
                }
            }
            ViewBag.RecommendedEvents = recommended.Distinct().Take(5).ToList();

            return View(result.ToList());
        }

        // View event by id (route uses 'id')
        public IActionResult ViewEvent(int id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
            {
                TempData["ErrorMessage"] = "Event not found.";
                return RedirectToAction("LocalEvents");
            }

            // show related recommended events
            ViewBag.RecommendedEvents = _events.Where(e => e.Category == ev.Category && e.Id != ev.Id).Take(3).ToList();
            return View(ev);
        }

        // Error action (keeps previous behavior)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
