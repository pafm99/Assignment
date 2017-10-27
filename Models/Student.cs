using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public abstract class BaseEntity {}
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public List<Belt> BeltsCreated { get; set;}
        public List<Category> BeltsAchieved {get;set;}
        public Student() {
            BeltsAchieved = new List<Category>();
            BeltsCreated = new List<Belt>();
        }
    }
}