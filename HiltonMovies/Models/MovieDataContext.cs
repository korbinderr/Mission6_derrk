using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonMovies.Models
{
    public class MovieDataContext : DbContext
    {
        //Constructor (inheriting from the standard general DbContext, and inheriting those standard options
        public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options)
        {
            //Leave blank for now
        }

        // Creating a set of data from our form so that you can now call context.responses and its a list/set of data from our DB
        public DbSet<MovieResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(

                    new MovieResponse
                    {
                        MovieID = 1,
                        category = "Action/Adventure",
                        title = "Boondock Saints, The",
                        year = 1999,
                        director = "Troy Duffy",
                        rating = "R",
                        edited = true,
                        lent = "",
                        notes = ""
                    },

                    new MovieResponse
                    {
                        MovieID = 2,
                        category = "Action/Adventure",
                        title = "Dark Knight Rises, The",
                        year = 2012,
                        director = "Christopher Nolan",
                        rating = "PG-13",
                        edited = false,
                        lent = "",
                        notes = ""
                    },

                    new MovieResponse
                    {
                        MovieID = 3,
                        category = "Action/Adventure",
                        title = "Die Hard",
                        year = 1988,
                        director = "John McTiernan",
                        rating = "R",
                        edited = true,
                        lent = "",
                        notes = ""
                    }
            );
        }
    }
}
