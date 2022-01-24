using System;
using System.ComponentModel.DataAnnotations;

namespace Test2_API.model
{
    public class Grade
    {
        [Key]
        public Int32 GradeId { get; set; }

        [Required]
        public Int32 GradeName { get; set; }

        [Required]
        public DateTime GradeDateTime { get; set; }
    }
}
