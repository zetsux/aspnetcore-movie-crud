using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PBKK_RazorpageMovie.Data;
using RazorPagesMovie.Models;

namespace PBKK_RazorpageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly PBKK_RazorpageMovie.Data.PBKK_RazorpageMovieContext _context;

        public IndexModel(PBKK_RazorpageMovie.Data.PBKK_RazorpageMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;
        public SelectList Genres;
        public string MovieGenre { get; set; }

        public async Task OnGetAsync(string searchString, string movieGenre)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
