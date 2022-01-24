using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test2_API.model;

namespace SchooApi.model
{
    public class Subject
    {
        [Key]
        public Int32 SubjectId { get; set; }

        [Required]
        public String SubjectName { get; set; }

        [Required]
        public Boolean SubjectExam { get; set; } = true;
        
        [Required]
        public List<Grade> Grades { get; set; }
    }
}
