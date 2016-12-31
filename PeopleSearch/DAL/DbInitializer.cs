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
            new Person{FirstName="Carson", LastName="Alexander", BirthDate=DateTime.Parse("1991-09-01"),
                Street="465 Aspen Grove", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp1.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Meredith", LastName="Alonso", BirthDate=DateTime.Parse("1989-09-01"),
                Street="123 Elm Street", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp6.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Jason", LastName="Bourne", BirthDate=DateTime.Parse("1970-09-01"),
                Street="729 Evergreen Street", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp2.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Jared", LastName="Smith", BirthDate=DateTime.Parse("1985-09-01"),
                Street="68 Birch Street", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp5.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Elizabeth", LastName="Wright", BirthDate=DateTime.Parse("1986-09-01"),
                Street="34 Spruce Lane", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp4.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Laura", LastName="Norman", BirthDate=DateTime.Parse("1975-09-01"),
                Street="13 Maple Circle", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp3.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Dan", LastName="Brown", BirthDate=DateTime.Parse("1976-09-01"),
                Street="51 Ash Street", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp7.jpg", Interests = new List<Interest>()}
            };

            var soccerInterest = new Interest { Title = "Soccer" };
            var footballInterest = new Interest { Title = "Football" };
            var mountainBikingInterest = new Interest { Title = "Mountain Biking" };
            var runningInterest = new Interest { Title = "Running" };
            var choirInterest = new Interest { Title = "Choir" };
            var bandInterest = new Interest { Title = "Band" };
            var orchestraInterest = new Interest { Title = "Orchestra" };

            people[0].Interests.Add(soccerInterest);
            people[0].Interests.Add(footballInterest);
            people[0].Interests.Add(mountainBikingInterest);
            people[1].Interests.Add(choirInterest);
            people[1].Interests.Add(bandInterest);
            people[1].Interests.Add(orchestraInterest);
            people[2].Interests.Add(mountainBikingInterest);
            people[2].Interests.Add(choirInterest);
            people[3].Interests.Add(footballInterest);
            people[3].Interests.Add(bandInterest);
            people[4].Interests.Add(mountainBikingInterest);
            people[4].Interests.Add(runningInterest);
            people[5].Interests.Add(choirInterest);
            people[6].Interests.Add(bandInterest);

            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();
        }
    }
}