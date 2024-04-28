using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Models;

namespace RazorPageProject.Data
{
    public class RazorPageProjectContext : DbContext
    {
        public RazorPageProjectContext (DbContextOptions<RazorPageProjectContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGames> VideoGames { get; set; } = default!;
    }
}
