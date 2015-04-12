// <copyright file="UIDeleteTest.cs" company="engi">
// UI Test Delete for the project.
// </copyright>
namespace DTest
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
    /// Class for the UI Delete test
    /// </summary>
    [TestClass]
    public class UIDeleteTest
    {
        /// <summary>
        /// UI test for the Delete of CRUD
        /// </summary>
        /// <param name="driver">Browser selenium is using</param>
        [TestMethod]
        public static void RunUIDTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost/ASP.NET/GUI.aspx");
             IWebElement row = driver.FindElement(By.TagName("tr"));

            char[] space = { ' ' };
            string[] cells;
            string tempdb;

            IWebElement iwe = row;
           
                cells = iwe.Text.Split(space);
                tempdb = cells[0];
                          
                driver.FindElement(By.XPath("//input[@type = 'button'][@value = 'Delete']")).Click();

                row = driver.FindElement(By.TagName("tr"));
                cells = iwe.Text.Split(space);
                Assert.AreNotEqual(tempdb, cells[0], "ERROR:ID IS THE SAME:DELETE DID NOT WORK");
        }

        /// <summary>
        /// Run Chrome Test for this UI Test
        /// </summary>
        [TestMethod]
        public void DChromeTest()
        {
            ChromeDriver chrome = new ChromeDriver();
            RunUIDTest(chrome);
        }

        /// <summary>
        /// Run IE Test for this UI Test
        /// </summary>
        [TestMethod]
        public void DIETest()
        {
            InternetExplorerDriver ie = new InternetExplorerDriver();
            RunUIDTest(ie);
        }
    }
}
