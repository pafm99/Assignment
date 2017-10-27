using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BeltId { get; set; }
        public Belt Belt { get; set; }
        public DateTime DateAchieved {get; set;}
        public string BeltCategory {get; set;}
               

    }
}