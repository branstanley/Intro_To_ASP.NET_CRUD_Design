// <copyright file="UICreateTest.cs" company="engi">
// UI Test Create for the project.
// </copyright>
namespace CTest
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Testing;

    /// <summary>
    /// Class for Create UI test
    /// </summary>
    [TestClass]
    public class UICreateTest
    {
        /// <summary>
        /// UI Test for Create of CRUD
        /// </summary>
        /// <param name="driver">Browser selenium is using</param>
        [TestMethod]
        public static void RunUICTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost/ASP.NET/GUI.aspx");
        
            driver.FindElement(By.XPath("//input[@type = 'text'][@name = 'breed_create']")).SendKeys("Poodle");
            driver.FindElement(By.XPath("//input[@type = 'text'][@name = 'weight_create']")).SendKeys("10");
            driver.FindElement(By.XPath("//input[@type = 'text'][@name = 'age_create']")).SendKeys("5");
            driver.FindElement(By.XPath("//input[@type = 'submit'][@value = 'Create']")).Click();
           
            IWebElement breed = driver.FindElement(By.Name("breed_content3"));
            IWebElement weight = driver.FindElement(By.Name("weight_content3"));
            IWebElement age = driver.FindElement(By.Name("age_content3"));
            
            Assert.AreEqual(breed, "Poodle", "ERROR:THE BREED ARE NOT THE SAME:CREATE DID NOT WORK");
            Assert.AreEqual(weight, "10", "ERROR:THE WEIGHT ARE NOT THE SAME:CREATE DID NOT WORK");
            Assert.AreEqual(age, "5", "ERROR:THE AGE ARE NOT THE SAME:CREATE DID NOT WORK");
        }

        /// <summary>
        /// Run Chrome Test for this UI Test
        /// </summary>
        [TestMethod]
        public void CChromeTest()
        {
            ChromeDriver chrome = new ChromeDriver();
            RunUICTest(chrome);
        }

        /// <summary>
        /// Run IE Test for this UI Test
        /// </summary>
        [TestMethod]
        public void CIETest()
        {
            InternetExplorerDriver ie = new InternetExplorerDriver();
            RunUICTest(ie);
        }
    }
}
