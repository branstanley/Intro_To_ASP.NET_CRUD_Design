// <copyright file="UnitTest.cs" company="engi">
// Unit Test for the project.
// </copyright>
namespace AnimalshelterASPtest
{
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUProj2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing;

   /// <summary>
   /// Class containing all the Unit tests
   /// </summary>
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Unit test for Read function
        /// </summary>
        [TestMethod]
        public void Readtest()
        {  
            foreach (Animal entry in AnimalAccess.Read())
            {            
                Assert.IsTrue(Dictionary.ExpectedValues.ContainsKey(entry.Id));
                Assert.AreEqual(Dictionary.ExpectedValues[entry.Id], entry.Breed);
                Assert.AreEqual(Dictionary.ExpectedValues[entry.Id], entry.Weight);
                Assert.AreEqual(Dictionary.ExpectedValues[entry.Id], entry.Age);
            }
        }

        /// <summary>
        /// This Unit Test method deletes a row from the Database, and ensures it does not exist in subsequent reads.
        /// </summary>
        [TestMethod]
        public void Deletetest()
        {
            AnimalAccess.Delete("2");
            foreach (Animal temp in AnimalAccess.Read())
            {
                Assert.AreNotEqual(temp.Id, 2, "Our row has not been deleted.");
            }
        }

        /// <summary>
        /// Unit Test for Create function
        /// </summary>
        [TestMethod]
        public void Createtest()
        {
            AnimalAccess.Create("Poodle", "10", "3");
            List<Animal> templist = AnimalAccess.Read();
            Assert.AreEqual(templist[templist.Count - 1].Breed, "Poodle", "Create did not work Breed diffrent");
            Assert.AreEqual(templist[templist.Count - 1].Weight, "10", "Create did not work Weight diffrent");
            Assert.AreEqual(templist[templist.Count - 1].Age, "3", "Create did not work Age diffrent");
        }

        /// <summary>
        /// Unit Test for Update Function
        /// </summary>
        [TestMethod]
        public void Updatetest()
        {
            AnimalAccess.Update("1", "Poodle", "10", "3");
            List<Animal> templist = AnimalAccess.Read();
            Assert.AreEqual(templist[1].Breed, "Poodle", "Update did not work Breed diffrent");
            Assert.AreEqual(templist[1].Weight, "10", "Update did not work Weight diffrent");
            Assert.AreEqual(templist[1].Age, "3", "Update did not work Age diffrent");
        }

        /// <summary>
        /// Injection attacks to test CRUD functionality
        /// </summary>
        [TestMethod]
        public void InjectionAttack()
        {
            AnimalAccess.Update("1);DROP TABLE animals;--", "P", "1", "1");
            AnimalAccess.Update("1", "P');DROP TABLE animals;--", "1", "1");
            AnimalAccess.Update("1", "P", "1);DROP TABLE animals;--", "1");
            AnimalAccess.Update("1", "P", "1", "1);DROP TABLE animals;--");
            AnimalAccess.Create("P');DROP TABLE animals;--", "1", "1");
            AnimalAccess.Create("P", "1);DROP TABLE animals;--", "1");
            AnimalAccess.Create("P", "1", "1);DROP TABLE animals;--");
            AnimalAccess.Delete("1);DROP TABLE animals;--");
        }
    }
}
