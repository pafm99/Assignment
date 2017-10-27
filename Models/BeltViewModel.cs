using System;
using System.ComponentModel.DataAnnotations;
namespace Assignment.Models
{
    public class BeltViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Color { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

    }
}