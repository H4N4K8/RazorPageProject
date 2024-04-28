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
    public class IndexModel : PageModel
    {
        private readonly RazorPageProject.Data.RazorPageProjectContext _context;

        public IndexModel(RazorPageProject.Data.RazorPageProjectContext context)
        {
            _context = context;
        }

        public IList<VideoGames> VideoGames { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? GameGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.VideoGames
                                            orderby m.Genre
                                            select m.Genre;
            var games = from m in _context.VideoGames
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                games = games.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(GameGenre))
            {
                games = games.Where(x => x.Genre == GameGenre);
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            }
                VideoGames = await games.ToListAsync();

            }
        }
    }
