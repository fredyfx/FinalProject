using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMusic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Models
{
    public class SeedData
    {
        /// <summary>
        /// Initializes the database with song data.
        /// </summary>
        /// <param name="serviceProvider">Mechanism to retrieve a service object (IServiceProvider)</param>
        public static void InitializeDb(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check for any songs in the DB
                if (context.Song.Any())
                {
                    return; // DB has already been initialized
                }

                // Provide data to initialize DB
                context.Song.AddRange(
                    new Song
                    {
                        Title = "Bad Moon Rising",
                        Artist = "Creedence Clearwater Revival",
                        Album = "Green River",
                        Year = 1969,
                        Genre = "Rock",
                    },

                    new Song
                    {
                        Title = "Colorado",
                        Artist = "The Flying Burrito Brothers",
                        Album = "Hot Burritos!",
                        Year = 1972,
                        Genre = "Alt-Country",
                    },

                    new Song
                    {
                        Title = "One Headlight",
                        Artist = "The Wallflowers",
                        Album = "Bringing Down The Horse",
                        Year = 1996,
                        Genre = "Adult Alternative",
                    },

                    new Song
                    {
                        Title = "The World Is Yours",
                        Artist = "Nas",
                        Album = "Illmatic",
                        Year = 1994,
                        Genre = "Hip-Hop",
                    },

                    new Song
                    {
                        Title = "Lovesong",
                        Artist = "The Cure",
                        Album = "Disintegration",
                        Year = 1989,
                        Genre = "Alternative",
                    },

                    new Song
                    {
                        Title = "Train in Vain",
                        Artist = "The Clash",
                        Album = "London Calling",
                        Year = 1979,
                        Genre = "Punk",
                    },

                    new Song
                    {
                        Title = "High and Dry",
                        Artist = "Radiohead",
                        Album = "The Bends",
                        Year = 1995,
                        Genre = "Alternative",
                    },

                    new Song
                    {
                        Title = "Dixieland Delight",
                        Artist = "Alabama",
                        Album = "The Closer You Get",
                        Year = 1983,
                        Genre = "Country",
                    },

                    new Song
                    {
                        Title = "Daydream Believer",
                        Artist = "The Monkees",
                        Album = "The Birds, the Bees, & the Monkees",
                        Year = 1968,
                        Genre = "Pop",
                    },

                    new Song
                    {
                        Title = "California Waiting",
                        Artist = "Kings of Leon",
                        Album = "Youth and Young Manhood",
                        Year = 2003,
                        Genre = "Rock",
                    }
                );

                // save the starting values into the DB
                context.SaveChanges();
            }
        }
    }
}
