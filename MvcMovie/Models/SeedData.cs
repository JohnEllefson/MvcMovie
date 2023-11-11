using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The R.M.",
                    ReleaseDate = DateTime.Parse("2003-1-31"),
                    Genre = "Comedy",
                    Price = 8.55M,
                    Rating = "PG",
                    ImageName = "TheRM"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Adventure",
                    Price = 7.99M,
                    Rating = "PG",
                    ImageName = "TheOtherSideOfHeaven"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven 2",
                    ReleaseDate = DateTime.Parse("2019-6-28"),
                    Genre = "Adventure",
                    Price = 9.99M,
                    Rating = "PG-13",
                    ImageName = "TheOtherSideOfHeaven2"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Price = 4.99M,
                    Rating = "PG",
                    ImageName = "MeetTheMormons"
                }
            );
            context.SaveChanges();
        }
    }
}