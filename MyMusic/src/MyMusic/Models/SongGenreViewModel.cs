using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Models
{
    public class SongGenreViewModel
    {
        public List<Song> songs;
        public SelectList genres;
        public string songGenre { get; set; }
    }
}

