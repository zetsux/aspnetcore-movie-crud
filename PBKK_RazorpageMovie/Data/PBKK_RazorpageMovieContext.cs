using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace PBKK_RazorpageMovie.Data
{
    public class PBKK_RazorpageMovieContext : DbContext
    {
        public PBKK_RazorpageMovieContext (DbContextOptions<PBKK_RazorpageMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
