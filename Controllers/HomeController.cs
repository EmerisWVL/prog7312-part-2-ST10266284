using Microsoft.AspNetCore.Mvc;
using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MunicipalServicesApp.Controllers
{
    public class HomeController : Controller
    {
        // Static list to store reports in memory
        private static readonly List<Report> _reports = new List<Report>();

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

            // Process uploaded files
            var attachmentPaths = new List<string>();
            foreach (var file in mediaAttachments)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    attachmentPaths.Add($"/uploads/{fileName}");
                }
            }

            // Create and store report
            model.SubmissionTimestamp = DateTime.Now;
            model.MediaAttachments = attachmentPaths;
            _reports.Add(model);

            // Set success message for user feedback
            TempData["SuccessMessage"] = "Thank you for your report! Your input helps improve our community.";

            // Redirect to view the submitted report
            return RedirectToAction("ViewReport", new { index = _reports.Count - 1 });
        }
        public IActionResult ViewReport(int index)
        {
            if (index < 0 || index >= _reports.Count)
            {
                TempData["ErrorMessage"] = "Report not found.";
                return RedirectToAction("Index");
            }

            return View(_reports[index]);
        }
    }
}