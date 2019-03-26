using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskOdd.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [StringLength(100, MinimumLength =1)]
        [Display(Name ="Genre Name")]
        public string GenreName { get; set; }

        [Display(Name ="Description")] //без ограничения :Д:Д ок
        public string Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}