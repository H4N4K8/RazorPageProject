using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;

namespace RazorPageProject.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPageProjectContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPageProjectContext>>()))
        {
            if (context == null || context.VideoGames == null)
            {
                throw new ArgumentNullException("Null RazorPageProjectContext");
            }

            // Look for any movies.
            if (context.VideoGames.Any())
            {
                return;   // DB has been seeded
            }

            context.VideoGames.AddRange(
                new VideoGames
                {
                    Title = "Stardew Valley",
                    ReleaseDate = DateTime.Parse("2016-02-01"),
                    Genre = "Life Sim",
                    Price = 20.0M,
                    Rating = "10/10"
                },

                new VideoGames
                {
                    Title = "Final Fantasy VII Remake",
                    ReleaseDate = DateTime.Parse("2020-04-10"),
                    Genre = "Fantasy-Action RPG",
                    Price = 70.0M,
                    Rating = "10/10"
                },

                new VideoGames
                {
                    Title = "Sekiro: Shadows Die Twice",
                    ReleaseDate = DateTime.Parse("2019-03-22"),
                    Genre = "Action/Adventure",
                    Price = 30.0M,
                    Rating = "10/10"
                },

                new VideoGames
                {
                    Title = "Shadow of the Colossus",
                    ReleaseDate = DateTime.Parse("2005-10-18"),
                    Genre = "Action/Adventure, Puzzle",
                    Price = 20.0M,
                    Rating = "10/10"
                }
            );
            context.SaveChanges();
        }
    }
}
