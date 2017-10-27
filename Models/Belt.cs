using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    
    public class Belt
    {
        [Key]
        public int BeltId { get; set; }
        public string Color { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        
        
        public int StudentId {get; set;}
        public Student Student {get; set;}


        public List<Category> BeltsAchieved {get;set;}
        public Belt() {
            BeltsAchieved = new List<Category>();
        }
    }
}