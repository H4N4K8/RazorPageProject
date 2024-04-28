using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public DeleteModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoGames VideoGames { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VideoGames == null)
            {
                return NotFound();
            }

            var videogames = await _context.VideoGames.FirstOrDefaultAsync(m => m.Id == id);

            if (videogames == null)
            {
                return NotFound();
            }
            else
            {
                VideoGames = videogames;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogames = await _context.VideoGames.FindAsync(id);
            if (videogames != null)
            {
                VideoGames = videogames;
                _context.VideoGames.Remove(VideoGames);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
