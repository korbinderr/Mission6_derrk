using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonMovies.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public short year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lent { get; set; }
        [StringLength(25)]
        public string notes { get; set; }

        //build foreign key relationship
        [Required]
        public int categoryID { get; set; }
        public Category category { get; set; }
    }
}
