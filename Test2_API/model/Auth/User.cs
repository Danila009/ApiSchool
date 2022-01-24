using System;
using System.ComponentModel.DataAnnotations;

namespace Test2_API.model.Auth
{
    public class User
    {
        [Key]
        public Int32 UserId { get; set; }

        [Required]
        public String FIO { get; set; }
        
        [Required]
        public String Login { get; set; }

        [Required]
        public String Password { get; set; }
    }
}