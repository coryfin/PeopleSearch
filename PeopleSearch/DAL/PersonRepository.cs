using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeopleSearch.Models;

namespace PeopleSearch.DAL
{
    public class PersonRepository : IPersonRepository
    {
        private PeopleSearchContext _context;

        public PersonRepository(PeopleSearchContext context)
        {
            _context = context;
        }

    public virtual IEnumerable<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public virtual IEnumerable<Person> SearchPeople(string q)
        {
            return _context.People.Where(p => 
                    p.FirstName.ToLower().Contains(q.ToLower()) || 
                    p.LastName.ToLower().Contains(q.ToLower()))
                .ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}