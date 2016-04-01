using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchMovies.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<Actors> ListActors { get; set; }

        public string ListToActorsString
        {
            get
            {
                return string.Join(", ", ListActors);
            }
        }
    }
}