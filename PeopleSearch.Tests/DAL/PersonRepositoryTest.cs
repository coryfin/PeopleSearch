using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Moq;
using PeopleSearch.Controllers;
using PeopleSearch.DAL;
using PeopleSearch.Models;

namespace PeopleSearch.Tests.Controllers
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private List<Person> people;

        [TestInitialize]
        public void setup()
        {
            people = new List<Person>
            {
            new Person{FirstName="Carson", LastName="Alexander", BirthDate=DateTime.Parse("1991-09-01"),
                Street="465 Aspen Grove", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp1.jpg", Interests = new List<Interest>()},
            new Person{FirstName="Alex", LastName="Alonso", BirthDate=DateTime.Parse("1989-09-01"),
                Street="123 Elm Street", City="New York", State="NY", ZipCode="55555",
                ImageUrl="/content/images/emp6.jpg", Interests = new List<Interest>()},
            };

            var interests = new List<Interest>
            {
            new Interest{Title="Soccer"},
            new Interest{Title="Football"},
            new Interest{Title="Mountain Biking"},
            new Interest{Title="Running"},
            };

            people[0].Interests.Add(interests[0]);
            people[0].Interests.Add(interests[1]);
            people[1].Interests.Add(interests[2]);
            people[1].Interests.Add(interests[3]);
        }

        [TestMethod]
        public void GetAllPeople()
        {
            // Arrange
            var data = people.AsQueryable();
            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PeopleSearchContext>();
            mockContext.Setup(m => m.People).Returns(mockDbSet.Object);

            PersonRepository repository = new PersonRepository(mockContext.Object);

            // Act
            var result = repository.GetAllPeople();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void SearchPeople_all()
        {
            // Arrange
            string q = "alex";
            var data = people.AsQueryable();
            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PeopleSearchContext>();
            mockContext.Setup(m => m.People).Returns(mockDbSet.Object);

            PersonRepository repository = new PersonRepository(mockContext.Object);

            // Act
            var result = repository.SearchPeople(q);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void SearchPeople_one()
        {
            // Arrange
            string q = "Carson";
            var data = people.AsQueryable();
            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PeopleSearchContext>();
            mockContext.Setup(m => m.People).Returns(mockDbSet.Object);

            PersonRepository repository = new PersonRepository(mockContext.Object);

            // Act
            var result = repository.SearchPeople(q);

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void SearchPeople_none()
        {
            // Arrange
            string q = "jason";
            var data = people.AsQueryable();
            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PeopleSearchContext>();
            mockContext.Setup(m => m.People).Returns(mockDbSet.Object);

            PersonRepository repository = new PersonRepository(mockContext.Object);

            // Act
            var result = repository.SearchPeople(q);

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
