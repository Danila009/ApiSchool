using SchooApi.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test2_API.model
{
    public class School
    {
        [Key]
        public Int32 SchoolId { get; set; }
    
        [Required, MaxLength(64)]
        public String SchoolName { get; set; }

        [Required, MaxLength(256)]
        public String SchoolDescription { get; set; }

        [Required]
        public Double SchoolMapOne { get; set; }
        
        [Required]
        public Double SchoolMapTwo { get; set; }

        [Required]
        public Director Director { get; set; }

        [Required]
        public List<Student> Students { get; set; }

        [Required]
        public virtual List<Teacher> Teachers { get; set; } 
    
        public School()
        {
            Teachers = new List<Teacher>();
        }
    }
}
