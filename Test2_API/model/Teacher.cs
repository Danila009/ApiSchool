using System;
using System.ComponentModel.DataAnnotations;

namespace SchooApi.model
{
    public class Teacher
    {
        [Key]
        public Int32 TeacherId { get; set; }
    
        [Required]
        public String TeacherName { get; set; }

        [Required]
        public String TeacherDescription { get; set; }

    }
}
