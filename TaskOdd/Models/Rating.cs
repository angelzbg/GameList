using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskOdd.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Rating Value")]
        public string RatingValue { get; set; }

        [Display(Name = "Description")]
        [StringLength(400, MinimumLength =1)]
        public string Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}