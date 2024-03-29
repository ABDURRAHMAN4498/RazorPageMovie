using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{

    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public EditModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieUpdate = await _context.Movie.FindAsync(id);
            if (movieUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(movieUpdate,
            "Movie",
             m => m.Title, m => m.ReleaseDate,
            m => m.Genre, m => m.Price,m=>m.Rating))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();


            #region //dokmantasyon kodu
            //     if (!ModelState.IsValid)
            //     {
            //         return Page();
            //     }

            //     _context.Attach(Movie).State = EntityState.Modified;

            //     try
            //     {
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!MovieExists(Movie.ID))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }

            //     return RedirectToPage("./Index");
            // }

            // private bool MovieExists(int id)
            // {
            //     return (_context.Movie?.Any(e => e.ID == id)).GetValueOrDefault();
            // }

            #endregion
        }
    }
}