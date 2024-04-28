using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public EditModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoGames VideoGames { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id ==null || _context.VideoGames == null)
            {
                return NotFound();
            }

            var videogames =  await _context.VideoGames.FirstOrDefaultAsync(m => m.Id == id);
            if (videogames == null)
            {
                return NotFound();
            }
            VideoGames = videogames;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VideoGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGamesExists(VideoGames.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VideoGamesExists(int id)
        {
            return (_context.VideoGames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
