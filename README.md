# Municipal Services Application

Hey! This is my Municipal Services Application, built in **C# ASP.NET Core MVC**, for reporting municipal issues in South Africa. Right now, the app only has the **“Report Issues”** feature, where users can submit and view reports. It’s got a **responsive UI**, gives **real-time feedback**, and keeps reports in memory.

## 1. What You Need
Before running this project, make sure you have:  
- **Visual Studio Code** with the C# extension (OmniSharp).  
- **.NET 6.0 SDK** (download here: [dotnet download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)).  
- A modern web browser like Chrome, Edge, or Firefox.  

## 2. Setting Up the Project
1. Create the MVC project: 
dotnet new mvc -n MunicipalServicesApp
cd MunicipalServicesApp

2. Add or replace these files in the project folder:  
- `Models/Report.cs`  
- `Controllers/HomeController.cs`  
- `Views/Home/Index.cshtml`  
- `Views/Home/ReportIssue.cshtml`  
- `Views/Home/ViewReport.cshtml`  
- `Views/Shared/_Layout.cshtml`  
- `wwwroot/css/site.css`  
- `wwwroot/js/site.js`  
- `Program.cs`  
- `appsettings.json`  
- `readme.txt`  

3. Create an **uploads folder** for file attachments:  
mkdir wwwroot/uploads 

Make sure this folder is writable so file uploads work correctly.  

## 3. Compile and Run
1. Restore all dependencies: 
dotnet restore

2. Build the project:  
dotnet build

3. Run it:  
dotnet run

4. Open your browser and go to the URL shown in the terminal.  

## 4. How to Use
- **Home Page:** You’ll see three buttons:  
- **Report Issues** (clickable)  
- **Local Events and Announcements** (disabled for now)  
- **Service Request Status** (disabled for now)  

- **Report Issues Page:**  
1. Enter the location of the issue.  
2. Pick a category (Sanitation, Roads, Utilities).  
3. Describe the problem.  
4. Attach files if needed (`.jpg`, `.png`, `.pdf`, `.docx`).  
5. Click **Submit** - a progress bar shows while it’s processing, then a success message pops up.  
6. You can view the report details: location, category, description, timestamp, and attachments.  
7. Click **Back to Main Menu** to return.  

The UI is **responsive**, includes **animations** like button hover, page fade-in, and alert bounce-in, and uses a modern design with **Bootstrap 5** and custom CSS.  

## 5. Notes
- Reports are stored in memory, so they disappear when the app restarts. If you want persistence, you’d need to connect a database.  
- File uploads are saved in `wwwroot/uploads`.  
- Uses **Bootstrap 5** for responsive layouts and **Animate.css** for animations.  
- Targets **.NET 6.0** to work with the `dotnet new mvc` template.  
- To keep things tidy, I removed unnecessary template files like `Views/Home/Privacy.cshtml`.  

If anything goes wrong, check the code comments, make sure .NET 6.0 is installed, and double-check that the uploads folder exists and is writable.


