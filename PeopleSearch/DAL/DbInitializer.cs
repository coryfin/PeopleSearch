using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PeopleSearch.Models;

namespace PeopleSearch.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleSearchContext>
    {
        protected override void Seed(PeopleSearchContext context)
        {
            var people = new List<Person>
            {
            new Person{FirstName="Carson", LastName="Alexander", BirthDate=DateTime.Parse("2005-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Meredith", LastName="Alonso", BirthDate=DateTime.Parse("2002-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Arturo", LastName="Anand", BirthDate=DateTime.Parse("2003-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Gytis", LastName="Barzdukas", BirthDate=DateTime.Parse("2002-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Yan", LastName="Li", BirthDate=DateTime.Parse("2002-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Peggy", LastName="Justice", BirthDate=DateTime.Parse("2001-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Laura", LastName="Norman", BirthDate=DateTime.Parse("2003-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"},
            new Person{FirstName="Nino", LastName="Olivetto", BirthDate=DateTime.Parse("2005-09-01"), Interests = new List<Interest>(),
                Street="123 Elm Street", City="New York", State="New York", ZipCode="55555"}
            };

            var interests = new List<Interest>
            {
            new Interest{Title="Soccer"},
            new Interest{Title="Football"},
            new Interest{Title="Mountain Biking"},
            new Interest{Title="Running"},
            new Interest{Title="Choir"},
            new Interest{Title="Band"},
            new Interest{Title="Orchestra"}
            };

            people[0].Interests.Add(interests[0]);
            people[0].Interests.Add(interests[1]);
            people[0].Interests.Add(interests[2]);
            people[1].Interests.Add(interests[4]);
            people[1].Interests.Add(interests[5]);
            people[1].Interests.Add(interests[6]);
            people[2].Interests.Add(interests[2]);
            people[2].Interests.Add(interests[4]);
            people[3].Interests.Add(interests[1]);
            people[3].Interests.Add(interests[5]);
            people[4].Interests.Add(interests[2]);
            people[4].Interests.Add(interests[3]);
            people[5].Interests.Add(interests[4]);
            people[6].Interests.Add(interests[5]);

            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();
        }
    }
}