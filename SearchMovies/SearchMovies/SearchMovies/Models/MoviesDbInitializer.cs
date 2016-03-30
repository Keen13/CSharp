using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;

namespace SearchMovies.Models
{
    public class MoviesDbInitializer : DropCreateDatabaseAlways<MoviesContext>
    {
        //protected override void Seed(MoviesContext db)
        //{
        //    var arni = new Actors() { Name = "Арнольд", FirstName = "Шварценеггер" };
        //    var brus = new Actors() { Name = "Брюс", FirstName = "Уиллис" };

        //    db.Movies.Add(new Movies
        //        {
        //            Name = "Терминатор",
        //            Genre = "боевик",
        //            ListActors = ListActors(new ListStack<Actors>
        //            {
        //                arni
        //            })
        //        });

        //    db.Movies.Add(new Movies
        //        {
        //            Name = "Ред",
        //            Genre = "боевик",
        //            ListActors = ListActors(new ListStack<Actors>
        //            {
        //                arni,
        //                brus
        //            })
        //        });

        //    db.Movies.Add(new Movies
        //        {
        //            Name = "Крепкий орешик",
        //            Genre = "комедия",
        //            ListActors = ListActors(new ListStack<Actors>
        //            {
        //                brus
        //            })
        //        });

        //    base.Seed(db);
        //}

        private string ListActors(List<Actors> listActors)
        {
            return listActors.Aggregate(string.Empty, (current, actor) => current + actor.ToString() + " ");
        }
    }
}