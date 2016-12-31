using System.Data.Entity;
using PeopleSearch.Models;

namespace PeopleSearch.DAL
{
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext() : base("PeopleSearchContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
    }
}
