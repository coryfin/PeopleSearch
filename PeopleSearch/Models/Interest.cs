using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PeopleSearch.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public virtual ICollection<Person> People { get; set; }
    }
}