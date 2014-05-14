using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace TestApp
{
    /// <summary>
    /// User object
    /// </summary>
    public class User:IUser
    {
        #region " Properties "
        public string FirstName{get;set;}

        public string Surname { get; set; }

        public DateTime? DateOfBirth { get; set; }
        
        #endregion


        #region " Methods "

        /// <summary>
        /// Calculate the Age of the user from the date of birth.
        /// If Invalid date of birth is set throw an exception.
        /// </summary>
        /// <returns></returns>
        public int Age()
        {
            if (!DateOfBirth.HasValue || DateOfBirth.Value == DateTime.MinValue || DateOfBirth == DateTime.MaxValue)
            {
                throw new Exception("Invalid DateOfBirth");
            }
            return DateTime.Now.Year - DateOfBirth.Value.Year; 
        }

        #endregion

        #region " Constructors "

        public User(string firstName, string surname, DateTime? dateOfBirth) {

            FirstName = firstName;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }

        #endregion

    }
}


namespace TestUserObject
{
    /// <summary>
    /// Base class for the user object test
    /// </summary>
    [TestFixture]
    public class BaseUserTest
    {
        protected TestApp.IUser userObject;

        [SetUp]
        protected virtual void Init(){
            userObject = new TestApp.User("aaaa", "bbbb", new DateTime(1970, 1, 1));
        }
    }

    /// <summary>
    /// Test cases for user object
    /// </summary>
    [TestFixture]
    public class TestUserObject:BaseUserTest {

        [SetUp]
        protected override void Init()
        {
            base.Init();
        }

        /// <summary>
        /// Test if the user object is created with the correct values.
        /// </summary>
        [Test]
        public void TestUserDetails_001(){

            Assert.AreEqual("aaaa", userObject.FirstName);
            Assert.AreEqual("bbbb", userObject.Surname);
            Assert.AreEqual(44, userObject.Age());
        }

        /// <summary>
        /// Test for Invalid date of birth 
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Invalid DateOfBirth")]
        public void InvalidDateOfBirthException_002() {
            userObject.DateOfBirth = null;
            userObject.Age();
        }
    }
}