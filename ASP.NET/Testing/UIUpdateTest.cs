// <copyright file="UIUpdateTest.cs" company="engi">
// UI Test Update for the project.
// </copyright>
namespace UTest
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
    /// Class for the UI Update test
    /// </summary>
    [TestClass]
    public class UIUpdateTest
    {
        /// <summary>
        /// UI test for Update of CRUD
        /// </summary>
        /// <param name="driver">Browser selenium is using</param>
        [TestMethod]
        public static void RunUIUTest(IWebDriver driver)
        {
            Animal_dictionary animal1;
            Animal_dictionary animal2;
            driver.Navigate().GoToUrl("http://localhost/ASP.NET/GUI.aspx");
            IWebElement row = driver.FindElement(By.TagName("tr"));

            char[] space = { ' ' };
            string[] cells;

            IWebElement iwe = row;

            cells = iwe.Text.Split(space);
            animal1 = new Animal_dictionary(cells[1], float.Parse(cells[2]), float.Parse(cells[3]));

            driver.FindElement(By.XPath("//input[@type = 'text'][@name = 'breed_content1']")).SendKeys("Poodle");
            driver.FindElement(By.XPath("//input[@type = 'text'][@name = 'weight_content1']")).SendKeys("10");
            driver.FindElement(By.XPath("//input[@type = 'text'][@name = 'age_content1']")).SendKeys("5");
            driver.FindElement(By.XPath("//input[@type = 'submit'][@value = 'Update']")).Click();

            row = driver.FindElement(By.TagName("tr"));
            cells = iwe.Text.Split(space);
            animal2 = new Animal_dictionary(cells[1], float.Parse(cells[2]), float.Parse(cells[3]));
            Assert.AreNotEqual(animal1, animal2, "ERROR:THE COLUMNS ARE ALL THE SAME:UPDATE DID NOT WORK");
        }

        /// <summary>
        /// Run Chrome Test for this UI Test
        /// </summary>
        [TestMethod]
        public void UChromeTest()
        {
            ChromeDriver chrome = new ChromeDriver();
            RunUIUTest(chrome);
        }

        /// <summary>
        /// Run IE Test for this UI Test
        /// </summary>
        [TestMethod]
        public void UIETest()
        {
            InternetExplorerDriver ie = new InternetExplorerDriver();
            RunUIUTest(ie);
        }
    }
}
