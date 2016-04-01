using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchMovies.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
        {
            Database.SetInitializer<MoviesContext>(null);
        }

        public DbSet<Movies> Movies { get; set; }

        public DbSet<Actors> Actors { get; set; }


    }
}