using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        // private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        // // public DetailsModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        // // {
        // //     _context = context;
        // // }

        // [BindProperty]
        // public Movie Movie { get; set; }
        // public async Task<IActionResult> OnGetAsync(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

        //     if (Movie == null)
        //     {
        //         return NotFound();
        //     }
        //     return Page();
        // }
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DetailsModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            Movie = movie;
            return Page();
        }
    }
}