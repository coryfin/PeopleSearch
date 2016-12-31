using System;
using System.Collections.Generic;
using PeopleSearch.Models;

namespace PeopleSearch.DAL
{
    public interface IPersonRepository : IDisposable
    {
        IEnumerable<Person> GetAllPeople();
        IEnumerable<Person> SearchPeople(string q);
    }
}
