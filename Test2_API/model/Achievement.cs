using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchooApi.model
{
    public class Achievement
    {
        [Key]
        public Int32 AchievementId { get; set; }
        
        [Required, MaxLength(64)]
        public String AchievementName { get; set; }
        
        [Required, MaxLength(256)]
        public String AchievementDescription { get; set; }

    }
}
