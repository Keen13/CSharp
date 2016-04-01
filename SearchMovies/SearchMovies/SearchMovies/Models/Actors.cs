using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchMovies.Models
{
    public class Actors
    {
        public int ActorsId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MoviesId { get; set; }

        public virtual Movies Movies { get; set; }

        public override string ToString()
        {
            return string.Format("{1} {0}", FirstName, LastName);
        }
    }
}