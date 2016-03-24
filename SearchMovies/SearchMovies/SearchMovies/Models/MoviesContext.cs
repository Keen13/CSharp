using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchMovies.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movies> Movies { set; get; }
        public DbSet<Actors> Actors { set; get; }
    }
}