PROG7312 Part 1 - Municipal Services App
This is a C# ASP.NET Core MVC web application for reporting municipal issues in South Africa, developed for PROG7312 Part 1 (ST10266284). It implements the "Report Issues" functionality, allowing users to submit and view issue reports with a responsive UI, real-time feedback, and in-memory storage.
Features

Main Menu: Displays "Report Issues" (clickable) and disabled options for future features.
Report Issues: Submit location, category, description, and file attachments (.jpg, .png, .pdf, .docx).
View Report: View submitted report details after submission.
UI: Responsive design with Bootstrap 5, animations via Animate.css, and real-time feedback (progress bar, success message).

Setup and Usage
See readme.txt in the repository root for detailed instructions on requirements, setup, compilation, running, and usage.
Notes

Reports are stored in memory (non-persistent).
File uploads require a writable wwwroot/uploads folder.
Built with .NET 6.0.
