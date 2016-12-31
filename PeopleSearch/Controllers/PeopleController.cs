using System;
using System.Collections.Generic;
using System.Web.Http;
using PeopleSearch.Models;
using PeopleSearch.DAL;

namespace PeopleSearch.Controllers
{
    public class PeopleController : ApiController
    {
        private IPersonRepository _repository;

        public PeopleController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // GET: api/People
        public IEnumerable<Person> GetPeople(string q=null)
        {
            if (String.IsNullOrEmpty(q))
            {
                return _repository.GetAllPeople();
            }
            else
            {
                return _repository.SearchPeople(q);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}