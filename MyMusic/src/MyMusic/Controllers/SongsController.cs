using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMusic.Data;
using MyMusic.Models;

namespace MyMusic.Controllers
{
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Songs
        public async Task<IActionResult> Index(string songGenre, string titleString, string artistString,
            string albumString)
        {
            // LINQ to obtain a list of genres for a selectList for users
            IQueryable<string> genreQuery = from s in _context.Song
                                            orderby s.Genre
                                            select s.Genre;

            // LINQ to select songs
            var songs = from s in _context.Song
                        select s;
            
            // query for song title
            if (!string.IsNullOrEmpty(titleString))
            {
                songs = songs.Where(s => s.Title.Contains(titleString));
            }

            // query for song's Genre
            if (!string.IsNullOrEmpty(songGenre))
            {
                songs = songs.Where(s => s.Genre == songGenre);
            }

            // query for artist
            if (!string.IsNullOrEmpty(artistString))
            {
                songs = songs.Where(s => s.Artist.Contains(artistString));
            }

            // query for album
            if (!string.IsNullOrEmpty(albumString))
            {
                songs = songs.Where(s => s.Album.Contains(albumString));
            }

            // create a song genre view model to be rendered based on client choice
            var songGenreViewModel = new SongGenreViewModel();
            // only assign the view model if a query is created, and use distinct to ensure no duplicates
            songGenreViewModel.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            // also update songs list to reflect query
            songGenreViewModel.songs = await songs.ToListAsync();

            return View(songGenreViewModel);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.SingleOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Album,Artist,Genre,Title,Year")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.SingleOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Album,Artist,Genre,Title,Year")] Song song)
        {
            if (id != song.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.SingleOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.SingleOrDefaultAsync(m => m.ID == id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.ID == id);
        }
    }
}
