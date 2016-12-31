using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeopleSearch.Models;

namespace PeopleSearch.DAL
{
    public class PersonRepository : IPersonRepository
    {
        private PeopleSearchContext _context = new PeopleSearchContext();

        public virtual IEnumerable<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public virtual IEnumerable<Person> SearchPeople(string q)
        {
            return _context.People.Where(p => p.FirstName.Contains(q) || p.LastName.Contains(q)).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}