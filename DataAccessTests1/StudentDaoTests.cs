using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

using Common;

namespace DataAccess.Tests
{
    [TestClass()]
    public class StudentDaoTests
    {
        Mock<IDao<Student>> mockObject = null;
        readonly Student inputStudent = new Student() { StudentId = 1, Name = "Sergi", Surname = "Virgili", AgeOfBirth = DateTime.Parse("29/04/1980") };

        
        [TestInitialize]
        public void Setup()
        {
            mockObject = new Mock<IDao<Student>>();

            mockObject.Setup(x => x.Add(inputStudent)).Returns(inputStudent);
            mockObject.Setup(x => x.Add(null)).Throws<NullReferenceException>();
            mockObject.Setup(x => x.Delete(inputStudent)).Returns(true);
            mockObject.Setup(x => x.Delete(null)).Throws<NullReferenceException>();
            mockObject.Setup(x => x.Update(inputStudent)).Returns(inputStudent);
            mockObject.Setup(x => x.Update(null)).Throws<NullReferenceException>();
            mockObject.Setup(x => x.GetAll()).Returns(new List<Student> {inputStudent});
            mockObject.Setup(x => x.GetById(inputStudent.StudentId)).Returns(inputStudent);
            mockObject.Setup(x => x.Update(null)).Throws<NullReferenceException>();
        }

        [TestMethod()]
        public void AddTest()
        {
            var response = mockObject.Object.Add(inputStudent);
            Assert.AreEqual(inputStudent.Name, response.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]

        public void AddNullTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var response = mockObject.Object.Delete(inputStudent);
            Assert.AreEqual(true, response);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]

        public void DeleteNullTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var response = mockObject.Object.Update(inputStudent);
            Assert.AreEqual(inputStudent.Name, response.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]

        public void UpdateNullTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var expected = inputStudent.StudentId;
            var response = mockObject.Object.GetAll();
            Assert.AreEqual(expected, response[0].StudentId);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var expected = inputStudent;
            var response = mockObject.Object.GetById(inputStudent.StudentId);
            Assert.AreEqual(expected, response);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]

        public void GetByIdNullTest()
        {
            Assert.Fail();
        }
    }
}