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
        public DbSet<Category> Categories { get; set; }

        //Seeding movies
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                    new Category 
                    { 
                        categoryID = 1, 
                        category = "Action/Adventure"
                    },
                    new Category
                    {
                        categoryID = 2,
                        category = "Comedy"
                    },        
                    new Category
                    {
                        categoryID = 3,
                        category = "Drama"
                    },                    
                    new Category
                    {
                        categoryID = 4,
                        category = "Family"
                    },                    
                    new Category
                    {
                        categoryID = 5,
                        category = "Horror/Suspense"
                    },                   
                    new Category
                    {
                        categoryID = 6,
                        category = "Miscellaneous"
                    },
                    new Category
                    {
                        categoryID = 7,
                        category = "Television"
                    },
                    new Category
                    {
                        categoryID = 8,
                        category = "VHS"
                    }
                );


            mb.Entity<MovieResponse>().HasData(

                    new MovieResponse
                    {
                        MovieID = 1,
                        categoryID = 1,
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
                        categoryID = 1,
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
                        categoryID = 1,
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
