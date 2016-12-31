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
    public class PeopleControllerTest
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
        public void GetPeople_all()
        {
            // Arrange
            var data = people;

            var mockRepository = new Mock<PersonRepository>();
            mockRepository.Setup(m => m.GetAllPeople()).Returns(data);

            PeopleController controller = new PeopleController(mockRepository.Object);

            // Act
            var result = controller.GetPeople();

            // Assert
            mockRepository.Verify(m => m.GetAllPeople());
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetPeople_search_all()
        {
            // Arrange
            string q = "alex";
            var data = people;

            var mockRepository = new Mock<PersonRepository>();
            mockRepository.Setup(m => m.SearchPeople(It.Is<string>(s => s.Equals(q)))).Returns(data);

            PeopleController controller = new PeopleController(mockRepository.Object);

            // Act
            var result = controller.GetPeople(q);

            // Assert
            mockRepository.Verify(m => m.SearchPeople(q));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetPeople_search_one()
        {
            // Arrange
            string q = "carson";
            var data = people;

            var mockRepository = new Mock<PersonRepository>();
            mockRepository.Setup(m => m.SearchPeople(It.Is<string>(s => s.Equals(q)))).Returns(new List<Person> { data[0] });

            PeopleController controller = new PeopleController(mockRepository.Object);

            // Act
            var result = controller.GetPeople(q);

            // Assert
            mockRepository.Verify(m => m.SearchPeople(q));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void GetPeople_search_none()
        {
            // Arrange
            string q = "jason";
            var data = people;

            var mockRepository = new Mock<PersonRepository>();
            mockRepository.Setup(m => m.SearchPeople(It.Is<string>(s => s.Equals(q)))).Returns(new List<Person>());

            PeopleController controller = new PeopleController(mockRepository.Object);

            // Act
            var result = controller.GetPeople(q);

            // Assert
            mockRepository.Verify(m => m.SearchPeople(q));
            Assert.AreEqual(0, result.Count());
        }
    }
}
