using System;
using System.ComponentModel.DataAnnotations;
using Test2_API.model;

namespace SchooApi.model
{
    public class Director
    {
        [Key]
        public Int32 DirectorId { get; set; }

        [Required, MaxLength(64)]
        public String DirectorName { get; set; }
        [Required, MaxLength(256)]
        public String DirectorDescription { get; set; }

    }
}
