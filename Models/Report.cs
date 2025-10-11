using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MunicipalServicesApp.Models
{
    public class Report
    {
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        public List<string> MediaAttachments { get; set; } = new List<string>();

        public DateTime SubmissionTimestamp { get; set; } = DateTime.MinValue;
    }
}
