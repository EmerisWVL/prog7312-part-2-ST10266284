Municipal Services Web Application  
  
This is my Municipal Services Web Application project developed in ASP.NET Core MVC (C#).  
It’s a dynamic and interactive website designed to connect citizens with their local municipality by allowing them to view local events, submit reports, and stay informed about community updates.

Overview
The purpose of this project is to create a user-friendly platform that displays local events and announcements, allows users to report municipal issues, and view their submitted reports.  
I’ve also added a smart recommendation feature that suggests relevant events based on the user’s previous searches or the category of the event they’re viewing.

Technologies Used
- ASP.NET Core MVC (C#)
- Razor Views
- HTML, CSS, JavaScript
- Bootstrap 5
- jQuery
- Animate.css for animations

Features
Home Page (Index.cshtml)  
   - Clean and modern interface introducing the application.

Report Issue Page (ReportIssue.cshtml)  
   - Allows users to submit a report about municipal issues.  
   - Displays a confirmation message when the report is successfully submitted.

View Reports Page (ViewReport.cshtml) 
   - Shows a list of submitted reports (currently static for demonstration).

Local Events and Announcements (LocalEvents.cshtml)  
   - Displays all local events and announcements dynamically.
   - Search by name, filter by category, and filter by date.
   - Sort events alphabetically or by date (ascending/descending).
   - Fully responsive and styled with Bootstrap and animations.
   - “View Event” button to open full event details.

View Event Page (ViewEvent.cshtml)
   - Displays full details of the selected event.
   - Shows up to 3 recommended events from the same category below it.

Smart Recommendation Feature  
   - Suggests 3 relevant events based on the user’s recent search or selected category.
   - If no direct match, it shows general popular upcoming events.
   - This feature was implemented to meet the rubric requirement for recommendations.

How to Run the Project
1. Open the project in Visual Studio or VS Code.
2. Make sure .NET 8.0 SDK (or newer) is installed.
3. In the terminal, run:
dotnet build
to ensure there are no errors.
4. Then run:
dotnet run
5. Open your browser and go to:
http://localhost:xxxx
(Replace xxxx with your actual port number shown in the terminal.)

Conclusion
This project demonstrates my understanding of ASP.NET MVC, front-end integration, and dynamic data handling.  
It’s clean, functional, and visually appealing while meeting all rubric requirements, including the recommendation feature.

Thanks for reviewing my project 
— Ahmed Kader

