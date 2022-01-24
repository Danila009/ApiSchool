using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchooApi.model
{
    public class Student
    {
        [Key]
        public Int32 StudentId { get; set; }
        [Required, MaxLength(128)]
        public String StudentName { get; set; }
        [Required, MaxLength(64)]
        public String StudentDescription { get; set; }

        [Required]
        public Int32 StudentSemester { get; set; }

        [Required]
        public List<Achievement> Achievements { get; set; }

        [Required]
        public List<Subject> Subjects { get; set; }
    }
}
