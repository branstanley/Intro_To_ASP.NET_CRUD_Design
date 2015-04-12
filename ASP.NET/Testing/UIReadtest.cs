// <copyright file="UIReadTest.cs" company="engi">
// UI Test Read for the project.
// </copyright>
namespace RTest
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
    /// Class for the UI Read test
    /// </summary>
    [TestClass]
    public class UIReadtest
    {
        /// <summary>
        /// UI test for Read of Crud
        /// </summary>
        /// <param name="driver">Browser selenium is using</param>
        [TestMethod]
        public static void RunUIRTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost/ASP.NET/GUI.aspx");
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.TagName("tr"));

            char[] space = { ' ' };
            string[] cells;
            foreach (IWebElement iwe in rows)
            {
                cells = iwe.Text.Split(space);
                Assert.IsTrue(Dictionary.ExpectedValues.ContainsKey(int.Parse(cells[0])));
                Assert.AreEqual(Dictionary.ExpectedValues[int.Parse(cells[0])], float.Parse(cells[1]));
                Assert.AreEqual(Dictionary.ExpectedValues[int.Parse(cells[0])], float.Parse(cells[2]));
                Assert.AreEqual(Dictionary.ExpectedValues[int.Parse(cells[0])], float.Parse(cells[3]));
                }
            }

        /// <summary>
        /// Run Chrome Test for this UI Test
        /// </summary>
        [TestMethod]
        public void RChromeTest()
        {
            ChromeDriver chrome = new ChromeDriver();
            RunUIRTest(chrome);
        }

        /// <summary>
        /// Run IE Test for this UI Test
        /// </summary>
        [TestMethod]
        public void RIETest()
        {
            InternetExplorerDriver ie = new InternetExplorerDriver();
            RunUIRTest(ie);
        }
        }
    }