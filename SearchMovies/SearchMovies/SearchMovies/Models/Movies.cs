using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchMovies.Models
{
    public class Movies
    {
        public int MoviesId { set; get; }
        public string Name { set; get; }
        public string Genre { set; get; }
        public Actors ListActors { set; get; }
    }
}