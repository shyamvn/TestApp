using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace TestApp
{
    public class User:IUser
    {
        public string FirstName{get;set;}

        public string Surname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Age()
        {
            if (!DateOfBirth.HasValue || DateOfBirth.Value == DateTime.MinValue || DateOfBirth == DateTime.MaxValue)
            {
                throw new Exception("Invalid DateOfBirth");
            }
            return DateTime.Now.Year - DateOfBirth.Value.Year; 
        }

        public User(string firstName, string surname, DateTime? dateOfBirth) {

            FirstName = firstName;
            Surname = surname;
            DateOfBirth = dateOfBirth;
         }

    }
}


namespace TestUserObject
{

    [TestFixture]
    public class BaseUserTest
    {
        protected TestApp.User userObject;

        [SetUp]
        protected virtual void Init(){
            userObject = new TestApp.User("aaaa", "bbbb", new DateTime(1970, 1, 1));
        }
    }

    [TestFixture]
    public class TestUserObject:BaseUserTest {

        [SetUp]
        protected override void Init()
        {
            base.Init();
        }

        [Test]
        public void TestUserDetails_001(){

            Assert.AreEqual("aaaa", userObject.FirstName);
            Assert.AreEqual("bbbb", userObject.Surname);
            Assert.AreEqual(44, userObject.Age());
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Invalid DateOfBirth")]
        public void InvalidDateOfBirthException_002() {
            userObject.DateOfBirth = null;
            userObject.Age();
        }
    }
}