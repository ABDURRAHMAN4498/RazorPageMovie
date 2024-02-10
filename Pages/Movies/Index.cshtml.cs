using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPageMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        public IList<Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync(){
            if (_context.Movie != null){
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}