using System;

namespace MunicipalServicesApp.Models
{
    public class Event
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.MinValue;
        public string Description { get; set; } = string.Empty;

        // Parameterless constructor is fine for object initializers
        public Event() { }

        // Optional convenience constructor (not required)
        public Event(int id, string name, string category, DateTime date, string description)
        {
            Id = id;
            Name = name;
            Category = category;
            Date = date;
            Description = description;
        }
    }
}
