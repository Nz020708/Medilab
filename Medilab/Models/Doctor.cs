using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Medilab.Models
{
    public class Doctor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subtitle { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PersonImg { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string Time { get; set; }

        [NotMapped,Required(ErrorMessage ="Please select a file.")]
        public IFormFile Photo { get; set; }
    }
}
