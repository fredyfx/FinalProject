using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Models
{
    public class Song
    {
        public int ID { get; set; }

        // add validation with built in StringLength and Range
        // these return a built in validation message with client side Jquery

        [StringLength(60, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Artist { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Album { get; set; }

        [Range(0, 2100)]
        public int Year { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Genre { get; set; }
    }
}
