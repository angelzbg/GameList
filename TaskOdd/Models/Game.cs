using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskOdd.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        [StringLength(200, MinimumLength =1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release year")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Genre")]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [Display(Name = "Rating")]
        public int? RatingId { get; set; }
        public virtual Rating Rating { get; set; }
    }
}